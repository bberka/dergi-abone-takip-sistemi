using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
                c.Aboneliklers.Remove(abn);
                c.SaveChanges();
               
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
        public IActionResult Ekle(Abonelikler b)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    c.Aboneliklers.Add(b);
                    c.SaveChanges();
                    
                }
                catch
                {
                    
                }
            }
            return NoContent();


        }
    }
}
