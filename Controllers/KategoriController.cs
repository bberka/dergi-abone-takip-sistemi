using DergiAboneProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace DergiAboneProje.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {

        DergiDbContext c = new DergiDbContext();
        
        
        public IActionResult Liste()
        {
            
            var degerler = c.Kategorilers.ToList();
            return View(degerler);
        }
        
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Kategoriler k)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    c.Kategorilers.Add(k);
                    c.SaveChanges();
                    return RedirectToAction("Liste");
                }
                catch
                {
                    
                }
                
            }
            return NoContent();

        }
        public IActionResult Sil(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ktg = c.Kategorilers.Find(id);
                    c.Kategorilers.Remove(ktg);
                    c.SaveChanges();
                    return RedirectToAction("Liste");
                }
               catch
                {
                    
                }
            }
            return NoContent();
        }
        public IActionResult Detay(int id)
        {
            var degerler = c.Dergilers.Where(x => x.KategoriID == id).ToList();
            var ktgad = c.Kategorilers.Where(x => x.KategoriID == id).Select(y => y.KategoriAD).FirstOrDefault();
            ViewBag.kategoriad = ktgad;
            ViewBag.ktgid = id;
            return View(degerler);
        }
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            var ktg = c.Kategorilers.Find(id);
            return View("Duzenle",ktg);
        }
        [HttpPost]
        public IActionResult Duzenle(Kategoriler k)
        {
            try
            {
                c.Kategorilers.Update(k);
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
