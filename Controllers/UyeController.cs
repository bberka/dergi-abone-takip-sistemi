using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DergiAboneProje.Controllers
{
    [Authorize(Roles = "A,O")]
    public class UyeController : Controller
    {
        readonly DergiDbContext c = new DergiDbContext();
        public bool _AbonelikExistResult;
        public IActionResult Liste() //üye liste veritabanından çekilip viewe gönderiliyor
        {
            var degerler = c.Uyelers.ToList();
            return View(degerler);
        }
        public JsonResult CheckAbonelik(int id) //Uyenin mevcut abonelik kaydı varmı diye kontrol edilip view içinde kontrol ediliyor kullanıcıya uyarı veriliyor
        {
            bool AbonelikExist = c.Aboneliklers.Where(x => x.UyeID == id).Count() != 0;
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
            if (_AbonelikExistResult) //URL yazarak silmeyi engellemek için
            {
                return RedirectToAction("Liste");
            }
            else if (ModelState.IsValid)
            {
                try 
                {
                    var a = c.Uyelers.Find(id); //Silme işlemi
                    c.Uyelers.Remove(a);
                    c.SaveChanges();
                }
                catch
                {
                }
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
            //Ad ve email stringine trim uygulanıyor
            b.UyeAD = b.UyeAD.Trim();
            b.Email = b.Email.Trim();
            bool UyeAlreadyExist = c.Uyelers.Where(x => x.Email == b.Email).Count() != 0; //girilen emailin veritabanında kaydı varmı diye kontrol ediliyor 
            bool BirtDateCheck = Convert.ToDateTime(b.Tarih).AddYears(18) >= DateTime.Now; //Doğum tarihinin 18 yaşından büyük olduğu kontrol ediliyor.
            bool PhoneNumberCheck = b.TelNo.ToString().Length != 10 || !b.TelNo.ToString().All(char.IsDigit); //Telefon numarasına sayı girilip girilmediği kontrolü
            //Yukarıdaki kontrollere uygun validation uyarıları viewe gönderiliyor
            if (UyeAlreadyExist) ModelState.AddModelError("UyeAlreadyExist", "Bu email adresi zaten kullanılıyor.");
            else if (BirtDateCheck) ModelState.AddModelError("BirtDateCheck", "Üye 18 yaşından büyük olmalıdır.");
            else if (PhoneNumberCheck) ModelState.AddModelError("PhoneNumberCheck", "Geçersiz telefon numarası girdiniz.");
            else if (ModelState.IsValid)
            {
                try//veritabanı ekleme işlemi
                {
                    c.Uyelers.Add(b);
                    c.SaveChanges();
                    return RedirectToAction("Liste");
                }
                catch
                {
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            try//urlde verilen id nin verileri veritabanından çekiliyor
            {
                ViewBag.UID = id;
                var uye = c.Uyelers.Find(id);
                return View("Duzenle", uye);
            }
            catch
            {
            }
            return View();
        }
        [HttpPost]
        public IActionResult Duzenle(Uyeler b)
        {
            //Ad ve mail için trim
            b.UyeAD = b.UyeAD.Trim();
            b.Email = b.Email.Trim();
            //üye id yi viewbag olara view e yolluyor.
            ViewBag.UID = b.UyeID;

            bool ChangesMade = c.Uyelers.Where(x => x.Email == b.Email && x.UyeAD == b.UyeAD && x.Tarih == b.Tarih && x.TelNo == b.TelNo).Count() != 0; //verilerde değişiklik yapıldımı kontrol
            bool BirtDateCheck = Convert.ToDateTime(b.Tarih).AddYears(18) >= DateTime.Now; //18 yaş kontrolü
            bool PhoneNumberCheck = b.TelNo.ToString().Length != 10 || !b.TelNo.ToString().All(char.IsDigit); //telefon numarasında sadece sayı kontrolü
            bool UyeAlreadyExist = c.Uyelers.Where(x => x.Email == b.Email && x.UyeID != b.UyeID).Count() != 0; //mail verisi veritabanında varmı kontrolü
            //yukarıdaki kontrollere göre validation mesajları viewe yollanıyor
            if (ChangesMade) ModelState.AddModelError("ChangesMade", "Değişiklik yapmadınız.");
            else if (UyeAlreadyExist) ModelState.AddModelError("UyeAlreadyExist", "Bu email adresi zaten kullanılıyor.");
            else if (BirtDateCheck) ModelState.AddModelError("BirtDateCheck", "Üye 18 yaşından büyük olmalıdır.");
            else if (PhoneNumberCheck) ModelState.AddModelError("PhoneNumberCheck", "Geçersiz telefon numarası girdiniz.");
            else if (ModelState.IsValid)
            {
                try //veritabanı kayıt güncelleme işlemi
                {
                    c.Uyelers.Update(b);
                    c.SaveChanges();
                    return RedirectToAction("Liste");
                }
                catch
                {
                }
            }
            return View();
        }
        public IActionResult Detay(int id) //uye detay sayfası
        {
            var degerler = c.Aboneliklers.Where(x => x.UyeID == id)
                .Include(x => x.Dergi)
                .ToList();
            var uyead = c.Uyelers.Where(x => x.UyeID == id).Select(y => y.UyeAD).FirstOrDefault();
            ViewBag.uyead = uyead;
            ViewBag.uyeid = id;
            return View(degerler);
        }

    }
}
