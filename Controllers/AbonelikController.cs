using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace DergiAboneProje.Controllers
{
    [Authorize]
    public class AbonelikController : Controller
    {
        DergiDbContext c = new DergiDbContext();
        public IActionResult Liste()
        {
            TempData.Clear();
            var degerler = c.Aboneliklers
                .Include(x => x.Uye)
                .Include(x => x.Dergi)
                .ToList();
            return View(degerler);           
        }
        
       public IActionResult Sil(int id)
        {
            try
            {
                var abn = c.Aboneliklers.Find(id);
                c.Aboneliklers.Remove(abn);
                c.SaveChanges();
                //if (TempData.ContainsKey("UyeKey"))
                //{
                //    return RedirectToAction("Detay", "Uye",new { id =TempData["UyeKey"]});
                //}
                //else if (TempData.ContainsKey("DergiKey"))
                //{
                //    return RedirectToAction("Detay", "Dergi", new { id = TempData["DergiKey"] });
                //}
                //return RedirectToAction("Liste");
            }
            catch
            {

            }
            return NoContent();
        }
        public IActionResult Iptal(int id)
        {
            try
            {
                var abn = c.Aboneliklers.Find(id);
                abn.KayıtSuresi =  abn.KayıtSuresi - (abn.KayıtTarihi.AddDays(abn.KayıtSuresi) - DateTime.Now).Days;
                c.Aboneliklers.Update(abn);
                c.SaveChanges();
                //if (TempData.ContainsKey("UyeKey"))
                //{
                //    return RedirectToAction("Detay", "Uye", new { id = TempData["UyeKey"] });
                //}
                //else if (TempData.ContainsKey("DergiKey"))
                //{
                //    return RedirectToAction("Detay", "Dergi", new { id = TempData["DergiKey"] });
                //}
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
            List<SelectListItem> _uyeID = (from x in c.Uyelers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UyeAD,
                                                 Value = x.UyeID.ToString()
                                             }).ToList();
            ViewBag.uID = _uyeID;
            List<SelectListItem> _dergiID = (from x in c.Dergilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DergiAD,
                                                 Value = x.DergiID.ToString()
                                             }).ToList();
            ViewBag.dID = _dergiID;
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Abonelikler b)
        {
            b.KayıtSuresi *= 30;
      
            if (ModelState.IsValid)
            {
                try
                {
                    c.Aboneliklers.Add(b);
                    c.SaveChanges();
                    //return RedirectToAction("Liste");
                }
                catch
                {
                    
                }
            }
            return NoContent();


        }
      
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            List<SelectListItem> _uyeID = (from x in c.Uyelers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UyeAD,
                                               Value = x.UyeID.ToString()
                                           }).ToList();
            ViewBag.uID = _uyeID;
            List<SelectListItem> _dergiID = (from x in c.Dergilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DergiAD,
                                                 Value = x.DergiID.ToString()
                                             }).ToList();
            ViewBag.dID = _dergiID;
            ViewBag.kTarihi = c.Aboneliklers.Select(x => x.KayıtTarihi);
            var abone = c.Aboneliklers.Find(id);
            abone.KayıtSuresi /= 30;
            return View("Duzenle", abone);
        }
        [HttpPost]
        public IActionResult Duzenle(Abonelikler d)
        {
            try
            {
                d.KayıtSuresi *= 30;
                c.Aboneliklers.Update(d);
                c.SaveChanges();
                //return RedirectToAction("Liste");
            }
            catch
            {

            }
            return NoContent();
        }
    }
}
