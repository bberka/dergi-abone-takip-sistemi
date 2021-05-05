using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DergiAboneProje.Controllers
{
    [Authorize(Roles = "A,O")]
    public class KategoriController : Controller
    {
        readonly DergiDbContext c = new DergiDbContext();
        public IActionResult Liste()
        {
            var degerler = c.Kategorilers
                .Include(x => x.Dergilers)
                .ToList();

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
            k.KategoriAD = k.KategoriAD.Trim();
            bool NameAlreadyExist = c.Kategorilers.Where(x => x.KategoriAD == k.KategoriAD).Count() != 0;
            if (NameAlreadyExist)
            {
                ModelState.AddModelError("NameAlreadyExist", "Bu kategori adı zaten var.");

            }
            else if (ModelState.IsValid)
            {
                c.Kategorilers.Add(k);
                c.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View();

        }
        public bool _DergiExist;
        public JsonResult CheckDergi(int id)
        {
            bool DergiExist = c.Dergilers.Where(x => x.KategoriID == id).Count() != 0;
            if (DergiExist)
            {
                _DergiExist = true;
                return Json(new { result = true });
            }
            _DergiExist = false;
            return Json(new { result = false });
        }
        public IActionResult Sil(int id)
        {
            CheckDergi(id);
            if (_DergiExist) return RedirectToAction("Liste");
            else if (ModelState.IsValid)
            {
                try
                {
                    var ktg = c.Kategorilers.Find(id);
                    c.Kategorilers.Remove(ktg);
                    c.SaveChanges();
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
            ViewBag.ktgID = id;
            return View("Duzenle", ktg);
        }
        [HttpPost]
        public IActionResult Duzenle(Kategoriler k)
        {
            k.KategoriAD = k.KategoriAD.Trim();
            bool NameAlreadyExist = c.Kategorilers.Where(x => x.KategoriAD == k.KategoriAD).Count() != 0;
            bool NameSame = c.Kategorilers.Where(x => x.KategoriID == k.KategoriID && x.KategoriAD == k.KategoriAD).Count() != 0;

            if (NameSame) ModelState.AddModelError("NameSame", "Düzenleme yapmadınız.");
            else if (NameAlreadyExist) ModelState.AddModelError("NameAlreadyExist", "Bu kategori adı zaten var.");
            else if (ModelState.IsValid)
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
            }
            ViewBag.ktgID = k.KategoriID;
            return View();
        }
    }
}
