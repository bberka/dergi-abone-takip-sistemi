using DAboneTakip.Models;
using DAboneTakip.Models.ChartModels;
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
    [Authorize(Roles = "A")]
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
                    dergisayi = c.Dergilers.Where(a=> a.KategoriID == x.KategoriID).Count()
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
                    abonesayi = c.Aboneliklers.Where(a => a.DergiID == x.DergiID && a.KayıtTarihi.AddDays(a.KayıtSuresi- 1) > DateTime.Now).Count()
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
