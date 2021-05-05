using DAboneTakip.Models;
using DAboneTakip.Models.ChartModels;
using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DAboneTakip.Controllers
{
    [Authorize(Roles = "A,O")]
    public class HomeController : Controller
    {
        readonly DergiDbContext c = new DergiDbContext();
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

            int bugun_eklenen = 0;
            foreach (var x in c.Aboneliklers)
            {
                bool a = x.KayıtTarihi.ToShortDateString() == DateTime.Now.ToShortDateString();

                if (a)
                {
                    if (x.KayıtSuresi != 1)
                    {
                        bugun_eklenen++;
                    }

                }

            }
            ViewBag.bugun_eklenen = bugun_eklenen;

            int aktif_abone = 0;
            int bitecek_abone = 0;

            foreach (var x in c.Aboneliklers)
            {
                var a = (x.KayıtTarihi.AddDays(x.KayıtSuresi) - DateTime.Now).Days;
                if (a <= 0)
                {

                    continue;
                }
                aktif_abone++;
            }
            ViewBag.count_aktifabone = aktif_abone;

            foreach (var x in c.Aboneliklers)
            {
                var a = (x.KayıtTarihi.AddDays(x.KayıtSuresi) - DateTime.Now).Days;
                if (a <= 0 || a >= 30)
                {
                    continue;
                }
                bitecek_abone++;
            }
            ViewBag.count_bitecek = bitecek_abone;
            return View();
        }
        public List<ChartKategori> VKategoriChart()
        {
            List<ChartKategori> a = new List<ChartKategori>();
            using (var c = new DergiDbContext())
            {
                a = c.Kategorilers.Select(x => new ChartKategori
                {
                    kategori = x.KategoriAD,
                    dergisayi = c.Dergilers.Where(a => a.KategoriID == x.KategoriID).Count()
                }).ToList();
            }
            return a;
        }


        public List<ChartDergi> VDergiChart()
        {
            List<ChartDergi> a = new List<ChartDergi>();
            using (var c = new DergiDbContext())
            {
                a = c.Dergilers.Select(x => new ChartDergi
                {
                    dergi = x.DergiAD,
                    abonesayi = c.Aboneliklers.Where(a => a.DergiID == x.DergiID && a.KayıtTarihi.AddDays(a.KayıtSuresi - 1) > DateTime.Now).Count()
                }).ToList();
            }
            return a;
        }

        public IActionResult Privacy()
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

    }
}
