using DergiAboneProje.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneProje.Controllers
{
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
                    return View();
                }
                
            }
            return View();

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
                    return View();
                }
            }
            return View();
        }
    }
}
