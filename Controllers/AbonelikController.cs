using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DergiAboneProje.Controllers
{
    [Authorize]
    public class AbonelikController : Controller
    {
        DergiDbContext c = new DergiDbContext();
        public IActionResult Liste()
        {
            var degerler = c.Aboneliklers
                .Include(x => x.Uye)
                .Include(x => x.Dergi)
                .ToList();
            return View(degerler);           
        }
       
        public IActionResult Iptal(int id)
        {
            try
            {
                var abn = c.Aboneliklers.Find(id);
                abn.KayıtSuresi =  abn.KayıtSuresi - (abn.KayıtTarihi.AddDays(abn.KayıtSuresi) - DateTime.Now).Days;
                c.Aboneliklers.Update(abn);
                c.SaveChanges();
                return RedirectToAction("Liste");
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
                    return RedirectToAction("Liste");
                }
                catch
                {
                    
                }
            }
            return NoContent();


        }
        public IActionResult Pasif()
        {
            var degerler = c.Aboneliklers
                .Include(x => x.Uye)
                .Include(x => x.Dergi)
                .ToList();
            return View(degerler);
            
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
                //var p = c.Kategorilers
                //    .Where(x => x.KategoriID == d.Kategoriler.KategoriID)
                //    .FirstOrDefault();
                //d.Kategoriler = p;
                d.KayıtSuresi *= 30;
                c.Aboneliklers.Update(d);
                c.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {

            }
            return NoContent();
        }
    }
}
