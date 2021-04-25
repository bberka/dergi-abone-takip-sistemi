using DergiAboneProje.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
                var abn = c.Uyelers.Find(id);
                c.Uyelers.Remove(abn);
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
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Uyeler b)
        {
            if (ModelState.IsValid)
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
            return NoContent();

        }
    }
}
