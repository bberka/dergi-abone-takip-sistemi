using DergiAboneProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace DergiAboneProje.Controllers
{
    [Authorize]
    public class DergiController : Controller
    {
        DergiDbContext c = new DergiDbContext();
        public IActionResult Liste()
        {
            var degerler = c.Dergilers
                .Include(x => x.Kategoriler)
                .Include(x => x.Uyeler)
                .ToList();
            return View(degerler);
        }
        [HttpGet]   
        public IActionResult Ekle()
        {
            
            List<SelectListItem> degerler = (from x in c.Kategorilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAD,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Dergiler d)
        {
            try
            {             
                c.Dergilers.Add(d);
                c.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {
                
            }
            return NoContent();
        }
        public IActionResult Sil(int id)
        {
            try
            {
                var drg = c.Dergilers.Find(id);
                c.Dergilers.Remove(drg);
                c.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {
                
            }
            return NoContent();
        }
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            List<SelectListItem> degerler = (from x in c.Kategorilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAD,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            ViewBag.drgtrh = c.Dergilers.Select(x => x.DergiTARIH);
            var drg = c.Dergilers.Find(id);
            return View("Duzenle", drg);
        }
        [HttpPost]
        public IActionResult Duzenle(Dergiler d)
        {
            try
            {
                c.Dergilers.Update(d);
                c.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {

            }
            return NoContent();
        }
        public IActionResult Detay(int id)
        {
            TempData.Clear();
            TempData["DergiKey"] = id;

            var degerler = c.Aboneliklers
                .Where(x => x.DergiID == id)
                .Include(x => x.Uye)
                .ToList();
            var drgad = c.Dergilers
                .Where(x => x.DergiID == id)
                .Select(y => y.DergiAD)
                .FirstOrDefault();
            ViewBag.drgad = drgad;
            ViewBag.drgid = id;
            return View(degerler);
        }
    }
    
}
