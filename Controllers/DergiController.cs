using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DergiAboneProje.Controllers
{
    [Authorize(Roles = "A,O")]
    public class DergiController : Controller
    {
        readonly DergiDbContext c = new DergiDbContext();
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

            GetKategoriIDsList();
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Dergiler d)
        {
            d.DergiAD = d.DergiAD.Trim();
            bool NameAlreadyExist = c.Dergilers.Where(x => x.DergiAD == d.DergiAD).Count() != 0;
            if (NameAlreadyExist) ModelState.AddModelError("NameAlreadyExist", "Bu dergi adı zaten mevcut.");
            else if (ModelState.IsValid)
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
            }
            GetKategoriIDsList();
            return View();
        }
        public bool _AbonelikExistResult;
        public JsonResult CheckAbonelik(int id)
        {
            bool AbonelikExist = c.Aboneliklers.Where(x => x.DergiID == id).Count() != 0;
            if (AbonelikExist)
            {
                _AbonelikExistResult = true;
                return Json(new { result = true });
            }
            _AbonelikExistResult = false;
            return Json(new { result = false });
        }
        public IActionResult Sil(int id)
        {
            CheckAbonelik(id);
            if (_AbonelikExistResult) return RedirectToAction("Liste");
            else if (ModelState.IsValid)
            {
                try
                {
                    var drg = c.Dergilers.Find(id);
                    c.Dergilers.Remove(drg);
                    c.SaveChanges();
                    TempData.Clear();
                }
                catch
                {
                }
            }
            return NoContent();
        }

        public void GetKategoriIDsList()
        {
            List<SelectListItem> degerler = (from x in c.Kategorilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = "(" + x.KategoriID.ToString() + ") " + x.KategoriAD,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            //degerler.Insert(0,(new SelectListItem { Text = "Kategori Seçiniz...", Value = "0" }));
            ViewBag.KategoriID = degerler;
        }
        [HttpGet]
        public IActionResult Duzenle(int id)
        {

            GetKategoriIDsList();

            var drg = c.Dergilers.Find(id);
            ViewBag.drgid = id;
            ViewBag.drgtrh = drg.DergiTARIH.ToString("dd/MM/yyyy");
            return View("Duzenle", drg);
        }
        [HttpPost]
        public IActionResult Duzenle(Dergiler d)
        {
            d.DergiAD = d.DergiAD.Trim();
            bool NameAlreadyExist = c.Dergilers.Where(x => x.DergiAD == d.DergiAD && x.DergiID != d.DergiID).Count() != 0;
            bool NameSame = c.Dergilers.Where(x => x.DergiID == d.DergiID && x.DergiAD == d.DergiAD).Count() != 0;
            bool KategoriSame = c.Dergilers.Where(x => x.DergiID == d.DergiID && x.KategoriID == d.KategoriID).Count() != 0;

            if (NameSame && KategoriSame) ModelState.AddModelError("NameSame", "Düzenleme yapmadınız.");
            else if (NameAlreadyExist) ModelState.AddModelError("NameAlreadyExist", "Bu dergi adı zaten mevcut.");
            else if (ModelState.IsValid)
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
            }
            GetKategoriIDsList();

            var drg = c.Dergilers.Find(d.DergiID);
            ViewBag.drgid = drg.DergiID;
            ViewBag.drgtrh = drg.DergiTARIH.ToString("dd/MM/yyyy");
            return View("Duzenle", drg);
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
