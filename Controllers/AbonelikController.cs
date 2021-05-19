using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DergiAboneProje.Controllers
{
    [Authorize(Roles = "A,O")]
    public class AbonelikController : Controller
    {
        readonly DergiDbContext c = new DergiDbContext();
        public IActionResult Liste() //abonelik liste verileri viewe yollanıyor
        {            
            var degerler = c.Aboneliklers
                .Include(x => x.Uye)
                .Include(x => x.Dergi)
                .ToList();
            return View(degerler);
        }

        public IActionResult Sil(int id) //abonelik silme işlemi
        {
            //eğer id aktif aboneliğe aitse işlemi yapmaz önce aboneliğin iptal edilmesi gerekir arayüz buna zaten izin vermiyor ama url ile de işlem engellendi
            bool CheckAktifAbonelik = c.Aboneliklers.Where(x=> x.KayıtID ==  id && x.KayıtTarihi.AddDays(x.KayıtSuresiGun-1) > DateTime.Now).Count() != 0; 
            if (CheckAktifAbonelik) return RedirectToAction("Liste");
            else if (ModelState.IsValid)
            {
                try 
                {
                    //veritabanı silme işlemi
                    var abn = c.Aboneliklers.Find(id);
                    c.Aboneliklers.Remove(abn);
                    c.SaveChanges();
                }
                catch
                {

                }
            }
            return NoContent();
        }
        public IActionResult Iptal(int id)
        {
            var abn = c.Aboneliklers.Find(id);
            //pasif abonelik kontrolü bu işlem sadece aktif aboneliklere yapılabilir arayüz buna zaten izin vermiyor ama url ile de işlem engellendi
            bool CheckPasifAbonelik = c.Aboneliklers.Where(x => x.KayıtID == id && x.KayıtTarihi.AddDays(x.KayıtSuresiGun - 1) < DateTime.Now).Count() != 0; 
            
            if (CheckPasifAbonelik) return RedirectToAction("Liste");
            else if(ModelState.IsValid)
            {
                try
                {                   
                    //iptal işlemi
                    abn.KayıtSuresiGun -= (abn.KayıtTarihi.AddDays(abn.KayıtSuresiGun) - DateTime.Now).Days;
                    int aktifabonelikay = abn.KayıtSuresiGun / 30;
                    if (abn.KayıtSuresiGun < 11) abn.ToplamUcret = 0;
                    else if (aktifabonelikay >= 1)
                    {
                        int aylikucret = abn.ToplamUcret / abn.KayıtSuresiAy;
                        abn.ToplamUcret = aktifabonelikay * aylikucret;
                    }
                    c.Aboneliklers.Update(abn);
                    c.SaveChanges();
                }
                catch
                {
                }
            }
              
            return NoContent();
        }
        public void GetUye_DergiIDsList() //abonelik ekle view içinde bu fonksiyon uye id ve dergi id listesini getirir
        {
            List<SelectListItem> _uyeID = (from x in c.Uyelers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = "(" + x.UyeID.ToString() + ") " + x.UyeAD,
                                               Value = x.UyeID.ToString()
                                           }).ToList();
            ViewBag.UyeID = _uyeID;
            List<SelectListItem> _dergiID = (from x in c.Dergilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = "(" + x.DergiID.ToString() + ") " + x.DergiAD,
                                                 Value = x.DergiID.ToString()
                                             }).ToList();
            ViewBag.DergiID = _dergiID;
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            GetUye_DergiIDsList();
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Abonelikler b)
        {
            bool CheckAboneSuresi = b.KayıtSuresiAy > 24 || b.KayıtSuresiAy < 1; //girilien ay verisinin kontrolü            
            //aktif abonelik verisi kontrolü ve idsi
            var ActiveAbonelik = c.Aboneliklers.Where(x => x.UyeID == b.UyeID && x.DergiID == b.DergiID && x.KayıtTarihi.AddDays(x.KayıtSuresiGun - 2).Date >= DateTime.Now.Date);
            bool CheckActiveAbonelik = ActiveAbonelik.Count() != 0;            
            //yukarıdaki kontrollerin validtion uyarıları
            if (CheckActiveAbonelik)
            {
                var IDActiveAbonelik = ActiveAbonelik.FirstOrDefault().KayıtID;
                ModelState.AddModelError("CheckActiveAbonelik", "Bu üyenin bu dergiye zaten aktif bir üyeliği var. Abonelik ID: " + IDActiveAbonelik);
            }                                       
            else if (CheckAboneSuresi) ModelState.AddModelError("CheckAboneSuresi", "Abonelik süresi 24 aydan fazla ya da sıfır olamaz.");            
            else if (ModelState.IsValid)
            {
                try //veritabanı işlemleri
                {
                    b.ToplamUcret = c.Dergilers.Where(x => x.DergiID == b.DergiID).Select(x => x.AylikUcret).FirstOrDefault() * b.KayıtSuresiAy;
                    b.KayıtSuresiGun =  b.KayıtSuresiAy * 30; //kayıt süresi gün tanımlanıyor
                    c.Aboneliklers.Add(b);
                    c.SaveChanges();
                    return RedirectToAction("Liste");
                }
                catch
                {
                }

            }
            GetUye_DergiIDsList();
            return View();
        }

        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            //bitmiş abonelikler düzenlenemez
            bool CheckPasifAbonelik = c.Aboneliklers.Where(x => x.KayıtID == id && x.KayıtTarihi.AddDays(x.KayıtSuresiGun - 1) < DateTime.Now).Count() != 0;
            if (CheckPasifAbonelik) return RedirectToAction("Liste");            
            GetUye_DergiIDsList(); 
            var abone = c.Aboneliklers.Find(id);
            //kayıt tarihi ve kayıt id viewe yollanmak için tanımlanır.
            ViewBag.KayıtTarihi = abone.KayıtTarihi.ToShortDateString();
            ViewBag.KayıtID = id;
            return View("Duzenle", abone);
        }
        [HttpPost]
        public IActionResult Duzenle(Abonelikler b)
        {
            bool CheckAboneSuresi = b.KayıtSuresiAy > 24 || b.KayıtSuresiAy < 1; //girilien ay verisinin kontrolü
            b.KayıtSuresiGun =  b.KayıtSuresiAy * 30;
            //aktif abonelik verisi kontrolü ve idsi
            var ActiveAbonelik = c.Aboneliklers.Where(x => x.UyeID == b.UyeID && x.DergiID == b.DergiID && x.KayıtID != b.KayıtID && x.KayıtTarihi.AddDays(x.KayıtSuresiGun - 2).Date >= DateTime.Now.Date);
            bool CheckActiveAbonelik = ActiveAbonelik.Count() != 0;
            bool ChangesNotMade = c.Aboneliklers.Where(x => x.KayıtID == b.KayıtID && x.KayıtSuresiAy == b.KayıtSuresiAy && x.DergiID == b.DergiID && x.UyeID == b.UyeID).Count() != 0;

            //yukarıdaki kontrollerin validtion uyarıları
            if (CheckActiveAbonelik) 
            {
                var IDActiveAbonelik = ActiveAbonelik.FirstOrDefault().KayıtID;
                ModelState.AddModelError("CheckActiveAbonelik", "Bu üyenin bu dergiye zaten aktif bir üyeliği var. Abonelik ID: " + IDActiveAbonelik);
            } 
            else if (ChangesNotMade) ModelState.AddModelError("ChangesNotMade", "Düzenleme yapmadınız.");
            else if (CheckAboneSuresi) ModelState.AddModelError("CheckAboneSuresi", "Abonelik süresi 24 aydan fazla ya da sıfır olamaz.");
            else if (ModelState.IsValid)
            {
                try //veritabanı işlemleri
                {
                    b.ToplamUcret = c.Dergilers.Where(x => x.DergiID == b.DergiID).Select(x => x.AylikUcret).FirstOrDefault() * b.KayıtSuresiAy;
                    b.KayıtSuresiGun = b.KayıtSuresiAy * 30; //kayıt süresi gün tanımlanıyor
                    c.Aboneliklers.Update(b);
                    c.SaveChanges();                   
                    return RedirectToAction("Liste");
                }
                catch
                {
                }
            }
            //kayıt tarihi ve kayıt id viewe yollanmak için tanımlanır.
            ViewBag.KayıtTarihi = b.KayıtTarihi.ToShortDateString();
            ViewBag.KayıtID = b.KayıtID;
            GetUye_DergiIDsList();
            return View();
        }
    }
}
