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
        public bool _AbonelikExistResult;
        public JsonResult CheckAbonelik(int id) //dergide abonelik varmı kontrolü varsa silme işlemine izin vermez
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
        public void GetKategoriIDsList() //kategorileri listeye çeker
        {
            List<SelectListItem> degerler = (from x in c.Kategorilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = "(" + x.KategoriID.ToString() + ") " + x.KategoriAD,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();            
            ViewBag.KategoriID = degerler;
        }
        public IActionResult Liste()
        {
            //dergiler listesi veri çekme
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
            d.DergiAD = d.DergiAD.Trim(); //ada trim uygulanır
            bool NameAlreadyExist = c.Dergilers.Where(x => x.DergiAD == d.DergiAD).Count() != 0; //dergi adı varmı kontrolü 
            if (NameAlreadyExist) ModelState.AddModelError("NameAlreadyExist", "Bu dergi adı zaten mevcut."); //dergi adı varsa uyarı mesajı
            else if (d.AylikUcret.ToString().Length > 4) ModelState.AddModelError("AylıkÜcretFazla", "Aylık ücret 4 basamaktan fazla olamaz."); //aylık ücret uyarı mesajı
            else if (ModelState.IsValid)
            {
                try // veritabanı işlemleri 
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
       
       
        public IActionResult Sil(int id) //dergi silme işlemleri
        {
            CheckAbonelik(id);
            if (_AbonelikExistResult) return RedirectToAction("Liste"); //aboneliği olan dergiyi url ile silme işlemi engellenmesi
            else if (ModelState.IsValid)
            {
                try //veri tabanı işlemleri
                {
                    var drg = c.Dergilers.Find(id);
                    c.Dergilers.Remove(drg);
                    c.SaveChanges();                    
                }
                catch
                {
                }
            }
            return NoContent();
        }        
        [HttpGet]
        public IActionResult Duzenle(int id) //düzenleme işlemleri girilen idnin verileri çekilir yollanır
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
            d.DergiAD = d.DergiAD.Trim(); //ada trim uygulanır
            bool NameAlreadyExist = c.Dergilers.Where(x => x.DergiAD == d.DergiAD && x.DergiID != d.DergiID).Count() != 0; //dergi adı varmı kontrolü
            bool RecordSame = c.Dergilers.Where(x => x.DergiID == d.DergiID && x.DergiAD == d.DergiAD && x.KategoriID == d.KategoriID && x.AylikUcret == d.AylikUcret).Count() != 0; //değişiklik yapıldımı kontrolü
            
            //validation mesajları 
            if (RecordSame) ModelState.AddModelError("RecordSame", "Düzenleme yapmadınız.");
            else if (NameAlreadyExist) ModelState.AddModelError("NameAlreadyExist", "Bu dergi adı zaten mevcut.");
            else if (d.AylikUcret.ToString().Length > 4) ModelState.AddModelError("AylıkÜcretFazla", "Aylık ücret 4 basamaktan fazla olamaz."); //aylık ücret uyarı mesajı
            else if (ModelState.IsValid)
            {
                try //veritabanı işlemleri
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
            //düzenlenen derginin değişmeyecek verileri değişkenlere atanır view da gösterilmek için
            var drg = c.Dergilers.Find(d.DergiID);
            ViewBag.drgid = drg.DergiID;
            ViewBag.drgtrh = drg.DergiTARIH.ToString("dd/MM/yyyy");
            return View("Duzenle", drg);
        }

        public IActionResult Detay(int id) //dergilerin abonelik listesi 
        {           
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
