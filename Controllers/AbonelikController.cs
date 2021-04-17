using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DergiAboneProje.Models;

namespace DergiAboneProje.Controllers
{
    public class AbonelikController : Controller
    {
        DergiDbContext c = new DergiDbContext();
        public IActionResult Liste()
        {
            var degerler = c.Aboneliklers.ToList();
            return View(degerler);           
        }
        public IActionResult Iptal(int id)
        {
            try
            {
                var abn = c.Aboneliklers.Find(id);
                c.Aboneliklers.Remove(abn);
                c.SaveChanges();
                return RedirectToAction("Aboneler");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Abonelikler b)
        {
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
                    return View();
                }
            }
            return View();

            
        }
    }
}
