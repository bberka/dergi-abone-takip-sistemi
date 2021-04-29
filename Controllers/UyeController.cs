using DergiAboneProje.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DergiAboneProje.Controllers
{
    [Authorize]
    public class UyeController : Controller
    {
        DergiDbContext c = new DergiDbContext();
        public IActionResult Liste()
        {
            
            var degerler = c.Uyelers.ToList();
            return View(degerler);
        }
        public IActionResult Sil(int id)
        {
            try
            {
                var a = c.Uyelers.Find(id);
                c.Uyelers.Remove(a);
                c.SaveChanges();
                //return RedirectToAction("Liste");
            }
            catch
            {
                
            }
            
            return NoContent();
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Ekle(Uyeler b)
        {
            bool UyeAlreadyExist = c.Uyelers.Where(x => x.Email == b.Email).Count() != 0;
            bool BirtDateCheck = Convert.ToDateTime(b.Tarih).AddYears(18) >= DateTime.Now;
            bool PhoneNumberCheck = b.TelNo.ToString().Length != 10 || !b.TelNo.ToString().All(char.IsDigit) ;
            if (UyeAlreadyExist)
            {
                ModelState.AddModelError("UyeAlreadyExist", "Bu email adresi zaten kullanılıyor.");
            }
            else if (BirtDateCheck)
            {
                ModelState.AddModelError("BirtDateCheck", "Üye 18 yaşından büyük olmalıdır.");
            }
            else if (PhoneNumberCheck)
            {
                ModelState.AddModelError("PhoneNumberCheck", "Geçersiz telefon numarası girdiniz.");
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    c.Uyelers.Add(b);
                    c.SaveChanges();
                    return RedirectToAction("Liste");
                }
                catch
                {

                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            try
            {
                var uye = c.Uyelers.Find(id);
                return View("Duzenle", uye);
            }
            catch
            {

            }
            return View();
        }
        [HttpPost]
        public IActionResult Duzenle(Uyeler b)
        {

            bool ChangesMade = c.Uyelers.Where(x => x.Email == b.Email && x.UyeAD == b.UyeAD && x.Tarih == b.Tarih && x.TelNo == b.TelNo).Count() != 0;
            bool BirtDateCheck = Convert.ToDateTime(b.Tarih).AddYears(18) >= DateTime.Now;
            bool PhoneNumberCheck = b.TelNo.ToString().Length != 10 || !b.TelNo.ToString().All(char.IsDigit);
            if (ChangesMade)
            {
                ModelState.AddModelError("ChangesMade", "Değişiklik yapmadınız.");
            }
            else if (BirtDateCheck)
            {
                ModelState.AddModelError("BirtDateCheck", "Üye 18 yaşından büyük olmalıdır.");
            }
            else if (PhoneNumberCheck)
            {
                ModelState.AddModelError("PhoneNumberCheck", "Geçersiz telefon numarası girdiniz.");
            }
            else if (ModelState.IsValid)
            {
                try
                {

                    c.Uyelers.Update(b);
                    c.SaveChanges();
                    return RedirectToAction("Liste");
                }
                catch
                {

                }
            }
            return View();
        }
        public IActionResult Detay(int id)
        {
            TempData.Clear();
            TempData["UyeKey"] = id;

            var degerler = c.Aboneliklers.Where(x => x.UyeID == id)
                .Include(x => x.Dergi)
                .ToList();
            var uyead = c.Uyelers.Where(x => x.UyeID == id).Select(y => y.UyeAD).FirstOrDefault();
            ViewBag.uyead = uyead;
            ViewBag.uyeid = id;
            return View(degerler);
        }

    }
}
