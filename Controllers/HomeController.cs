using DAboneTakip.Models;
using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAboneTakip.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        DergiDbContext c = new DergiDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list_abone = c.Aboneliklers.ToList();
            var list_dergi = c.Dergilers.ToList();
            var list_kategori = c.Kategorilers.ToList();
            var list_uye = c.Uyelers.ToList();
            
            ViewBag.count_uye = list_uye.Count();
            ViewBag.count_kategori = list_kategori.Count();
            ViewBag.count_dergi = list_dergi.Count();
            ViewBag.count_abone = list_abone.Count();
           
            int aktif_abone = 0;
            int bitecek_abone = 0;
            foreach (var x in c.Aboneliklers)
            {
                if ((x.KayıtTarihi.AddDays(x.KayıtSuresi) - DateTime.Now).Days <= 0)
                {
                    continue;
                }
                aktif_abone++;
            }
            ViewBag.count_aktifabone = aktif_abone;

            foreach(var x in c.Aboneliklers)
            {
                if ((x.KayıtTarihi.AddDays(x.KayıtSuresi) - DateTime.Now).Days > 30)
                {
                    continue;
                }
                bitecek_abone++;
            }
            ViewBag.count_bitecek = bitecek_abone;
            return View();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TestView()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Example()
        {
            return View();
        }
    }
}
