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


            if (ModelState.IsValid)
            {
                if (b.TelNo.ToString().Length > 9)
                {
                    if (c.Uyelers.Where(x => x.TelNo == b.TelNo).Count() == 0)
                    {
                        try
                        {
                            c.Uyelers.Add(b);
                            c.SaveChanges();
                            //return RedirectToAction("Liste");
                        }
                        catch
                        {

                        }
                    }
                    
                }

            }
            return NoContent();

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
            return NoContent();
        }
        [HttpPost]
        public IActionResult Duzenle(Uyeler b)
        {
           
           
                if (b.TelNo.ToString().Length > 9)
                {
                    if (c.Uyelers.Where(x => x.TelNo == b.TelNo).Count() == 0)
                    {
                    try
                    {

                        c.Uyelers.Update(b);
                        c.SaveChanges();
                        //return RedirectToAction("Liste");
                    }
                    catch
                    {

                    }
                }
                
                }
                  
            return NoContent();
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
