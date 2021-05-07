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
        public bool _DergiExist;
        public JsonResult CheckDergi(int id) //bu kategoride dergi varmı kontrolü ona göre view de silme işlemi engellenir
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
        public IActionResult Liste() //kategoriler veritabanından çekilir
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
            k.KategoriAD = k.KategoriAD.Trim(); //ada trim uygular
            bool NameAlreadyExist = c.Kategorilers.Where(x => x.KategoriAD == k.KategoriAD).Count() != 0; //kategori adı veritabanında varmı kontrolü
            if (NameAlreadyExist) ModelState.AddModelError("NameAlreadyExist", "Bu kategori adı zaten var.");//kategori adı var validation uyarısı    
            else if (ModelState.IsValid) //veritabanı işlemleri
            {
                c.Kategorilers.Add(k);
                c.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View();

        }        
        
        public IActionResult Sil(int id)
        {
            CheckDergi(id);
            if (_DergiExist) return RedirectToAction("Liste"); //url ile silme işlemi engellenmesi 
            else if (ModelState.IsValid)
            {
                try //veritabanı işlemleri
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
        public IActionResult Detay(int id)//kategori detay sayfası dergileri listeler
        {
            var degerler = c.Dergilers.Where(x => x.KategoriID == id).ToList();
            var ktgad = c.Kategorilers.Where(x => x.KategoriID == id).Select(y => y.KategoriAD).FirstOrDefault();
            ViewBag.kategoriad = ktgad;
            ViewBag.ktgid = id;

            return View(degerler);
        }
        [HttpGet]
        public IActionResult Duzenle(int id) //girilen iddeki kategori verisini çeker
        {
            var ktg = c.Kategorilers.Find(id);
            ViewBag.ktgID = id;
            return View("Duzenle", ktg);
        }
        [HttpPost]
        public IActionResult Duzenle(Kategoriler k)
        {
            k.KategoriAD = k.KategoriAD.Trim(); //trim uygular 
            bool NameAlreadyExist = c.Kategorilers.Where(x => x.KategoriAD == k.KategoriAD).Count() != 0; //kategor adı varmı kontrolü
            bool NameSame = c.Kategorilers.Where(x => x.KategoriID == k.KategoriID && x.KategoriAD == k.KategoriAD).Count() != 0; //değişiklik yapıldımı uyarısı
            if (NameSame) ModelState.AddModelError("NameSame", "Düzenleme yapmadınız.");
            else if (NameAlreadyExist) ModelState.AddModelError("NameAlreadyExist", "Bu kategori adı zaten var.");
            else if (ModelState.IsValid)
            {
                try //veritabanı işlemleri
                {
                    c.Kategorilers.Update(k);
                    c.SaveChanges();
                    return RedirectToAction("Liste");
                }
                catch
                {
                }
            }
            //düzenlenen kategori idsini viewde çekmek için
            ViewBag.ktgID = k.KategoriID;
            return View();
        }
    }
}
