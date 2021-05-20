using DAboneTakip.Models;
using DAboneTakip.Models.AccountModels;
using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DAboneTakip.Controllers
{

    public class LoginController : Controller
    {
        readonly DergiDbContext c = new DergiDbContext();
        string _CurrentUserRole;
        public bool CreateDefaultAdmin() 
        {
            //eğer adminlerde owner rolünde hiçbir kayıt yok ise owner rolünde bir default hesap oluşturur 
            if (c.Admins.Where(x=> x.Rol == "O" ).ToList().Count is 0)
            {
                Admin defadmin = new Admin{ 
                KullaniciAD = "owner",
                Sifre = "123456",
                Rol = "O"
                };
                c.Admins.Add(defadmin);
                c.SaveChanges();
                return true;
            }
            return false;
        }
        public bool CheckIfOwner(int id) //verilen parametre id nin owner rolünde olup olmadığına bakılıyor
        {
            var a = c.Admins.Find(id);
            if (a.Rol == "O") return true;
            return false;
        }
        public int GetUserID() //Giriş yapmış kullanıcının idsini alır
        {
            if (User.Identity.IsAuthenticated)
            {
                string a = this.User.Identity.Name;
                int uid = c.Admins
                    .Where(x => x.KullaniciAD == a)
                    .Select(x => x.ID)
                    .FirstOrDefault();
                _CurrentUserRole = c.Admins
                    .Where(x => x.KullaniciAD == a)
                    .Select(x => x.Rol)
                    .FirstOrDefault(); //giriş yapmış kullanıcının rolünü alır
                ViewBag.UID = uid;
                return uid;
            }
            return -1;
        }

        public IActionResult ErisimEngel() 
        {
            //erişim engeli sayfası startup.cs e tanımlandı eğer kullanıcının yetkisi yoska bu sayfaya yönlendirir
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GirisYap()
        {
            CreateDefaultAdmin();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GirisYap(Admin p)
        {
            //giriş yapma işlemleri 
            bool PassCheck = false;
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAD == p.KullaniciAD && x.Sifre == p.Sifre);
            if (bilgiler != null)  PassCheck = string.Equals(bilgiler.Sifre, p.Sifre);  
            if (bilgiler == null || !PassCheck)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                return View();
            }
            else if (bilgiler != null || ModelState.IsValid)
            {
                var claims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Name,bilgiler.KullaniciAD),
                         new Claim(ClaimTypes.Role,bilgiler.Rol.ToUpper())
                    };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> CikisYap()
        {
            //çıkış yapma işlemleri
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap", "Login");
        }

        [Authorize(Roles = "O")]
        public IActionResult Adminler()
        {
            //Owner rolünde olmayan hesapları viewe yollar
            var degerler = c.Admins
                .Where(x=> x.Rol != "O")
                .ToList();
            return View(degerler);
        }

        [Authorize(Roles = "O")]
        public IActionResult Sil(int id)
        {
            if (CheckIfOwner(id)) return RedirectToAction("Adminler"); //eğer url ile owner hesabı silmeye çalışırsa engeller
            else if (ModelState.IsValid)
            {
                try //silme işlemi
                {
                    var admn = c.Admins.Find(id);
                    c.Admins.Remove(admn);
                    c.SaveChanges();
                }
                catch
                {
                }
            }
            return NoContent();
        }
        [HttpGet]
        [Authorize(Roles = "O")]
        public IActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "O")]
        public IActionResult AdminEkle(Admin a)
        {
            bool CheckSpace = false; //boşluk varmı kontrolü
            if (a.KullaniciAD != null)
            {
                CheckSpace = a.KullaniciAD.Contains(" ");
                a.KullaniciAD = a.KullaniciAD.Trim().ToLower();
            }                        
            if (a.Sifre != null)
            {
                a.Sifre = a.Sifre.Trim();
                CheckSpace = a.Sifre.Contains(" ");
            }
            bool CheckIfUserExist = c.Admins.Where(x => x.KullaniciAD == a.KullaniciAD).Count() != 0; //bu kullanıcı adı varmı kontrolü 
            //validation uyarıları
            if (CheckSpace) ModelState.AddModelError("", "Kullanıcı adı ve şifre boşluk içeremez.");
            else if (CheckIfUserExist) ModelState.AddModelError("", "Bu kullanıcı adı zaten kullanılıyor.");
            else if (a.KullaniciAD.ToLower() == "owner") ModelState.AddModelError("", "Owner kullanıcı adında bir admin eklenemez."); //owner default hesap olduğu için
            else if (ModelState.IsValid)
            {
                c.Admins.Add(a);
                c.SaveChanges();
                return RedirectToAction("Adminler");
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "O")]
        public IActionResult Duzenle(int id)
        {
            ViewBag._CurrentUserID = id;
            if (CheckIfOwner(id)) return RedirectToAction("Adminler"); //eğer url ile owner hesabı silmeye çalışırsa engeller
            //idsi girilen hesabın verilerini çeker
            else if (ModelState.IsValid)
            {
                var admin = c.Admins.Find(id);
                return View("Duzenle", admin);
            }
            return NoContent();

        }
        [HttpPost]
        [Authorize(Roles = "O")]
        public IActionResult Duzenle(Admin a)
        {
            bool CheckSpace = false;
            if (a.KullaniciAD != null) //kullanıcıadı null değilse trim uygulayıp boşluk içeriyor mu kontrolü
            {
                a.KullaniciAD = a.KullaniciAD.Trim().ToLower();
                CheckSpace = a.KullaniciAD.Contains(" ");                
            }
            if (a.Sifre != null) //şifre null değilse trim uygulayıp boşluk içeriyor mu kontrolü
            {
                a.Sifre = a.Sifre.Trim();
                CheckSpace = a.Sifre.Contains(" ");
            }
            //kullanıcı adı var mı kontrolü
            bool CheckIfUserExist = c.Admins
                .Where(x => x.KullaniciAD == a.KullaniciAD && x.ID != a.ID)
                .Count() != 0; 
            //değişiklik yapıldı mı kontrolü
            bool CheckChanges = c.Admins
                .Where(x => x.KullaniciAD == a.KullaniciAD && x.Sifre == a.Sifre && x.Rol == a.Rol)
                .Count() != 0;
            //yukarıdaki validationların uyarıları viewe yollanır
            if (CheckSpace) ModelState.AddModelError("", "Kullanıcı adı ve şifre boşluk içeremez.");
            else if(CheckIfUserExist) ModelState.AddModelError("", "Bu kullanıcı adı zaten kullanılıyor.");
            else if (CheckChanges) ModelState.AddModelError("", "Düzenleme yapmadınız.");
            else if (ModelState.IsValid)
            {
                c.Admins.Update(a);
                c.SaveChanges();
                return RedirectToAction("Adminler");
            }
            ViewBag._CurrentUserID = a.ID;
            return View("Duzenle", c.Admins.Find(a.ID));
        }

        [HttpGet]
        [Authorize(Roles = "O,A")]
        public IActionResult SifreDegis()
        {
            GetUserID(); //user idsini alır 
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "O,A")]
        public IActionResult SifreDegis(ChangePass a)
        {
            int id = GetUserID(); //user idsini değişkene atar
            bool CheckOldPass = c.Admins.Where(x => x.ID == id && x.Sifre == a.OldPass).Count() != 0; //mevcut şifre doğrumu kontrolü
            bool CheckNewPassMatch = a.NewPass == a.NewPass2; //yeni şifreler eşleşiyormu kontrolü
            var _admin = new Admin
            {
                ID = id,
                KullaniciAD = this.User.Identity.Name,
                Sifre = a.NewPass,
                Rol = _CurrentUserRole
            };
            //validation uyarıları
            
            if(!CheckOldPass) ModelState.AddModelError("", "Geçerli şifreyi yanlış girdiniz.");
            else if (!CheckNewPassMatch) ModelState.AddModelError("", "Yeni şifre eşleşmiyor.");
            else if(ModelState.IsValid) //veritabanı işlemleri
            {
                c.Admins.Update(_admin);
                c.SaveChanges();
                return RedirectToAction("CikisYap");
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "O,A")]
        public IActionResult KullaniciAdDegis()
        {
            GetUserID(); //user idsini alır 
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "O,A")]
        public IActionResult KullaniciAdDegis(ChangeUsername a)
        {
            bool CheckSpace = false;
            if (a.NewUsername != null)
            {
                CheckSpace = a.NewUsername.Contains(" ");
                a.NewUsername = a.NewUsername.Trim().ToLower();
            }
            int id = GetUserID(); //user idsini değişkene atar
            bool CheckPass = c.Admins.Where(x => x.ID == id && x.Sifre == a.Password).Count() != 0; //mevcut şifre doğrumu kontrolü
            bool CheckIfUserExist = c.Admins.Where(x => x.KullaniciAD == a.NewUsername && x.ID != id).Count() != 0; //kullanıcı adı varmı kontrolü

            //validation uyarıları

            if (CheckSpace) ModelState.AddModelError("", "Kullanıcı adı boşluk içeremez.");
            else if(!CheckPass) ModelState.AddModelError("", "Şifreyi yanlış girdiniz.");
            else if (CheckIfUserExist) ModelState.AddModelError("", "Bu kullanıcı adı zaten kullanılıyor.");
            else if (ModelState.IsValid) //veritabanı işlemleri
            {
                var _admin = new Admin
                {
                    ID = id,
                    KullaniciAD = a.NewUsername,
                    Sifre = a.Password,
                    Rol = _CurrentUserRole
                };
                c.Admins.Update(_admin);
                c.SaveChanges();
                return RedirectToAction("CikisYap");
            }
            return View();
        }
    }
}
