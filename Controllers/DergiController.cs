using DergiAboneProje.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneProje.Controllers
{
    public class DergiController : Controller
    {
        DergiDbContext c = new DergiDbContext();
        public IActionResult Liste()
        {
            var degerler = c.Dergilers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Dergiler d)
        {
           if (ModelState.IsValid)
            {
                try
                {
                    c.Dergilers.Add(d);
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
            try
            {
                var drg = c.Dergilers.Find(id);
                c.Dergilers.Remove(drg);
                c.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {
                return View();
            }
        }
    }
    
}
