using DAboneTakip.Models;
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
        public bool CheckIfOwner(int id)
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
                int uid = c.Admins.Where(x => x.KullaniciAD == a).Select(x => x.ID).FirstOrDefault();
                _CurrentUserRole = c.Admins.Where(x => x.KullaniciAD == a).Select(x => x.Rol).FirstOrDefault();
                ViewBag.UID = uid;
                return uid;
            }
            return -1;
        }
        public IActionResult ErisimEngel()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GirisYap(Admin p)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAD == p.KullaniciAD && x.Sifre == p.Sifre);

            if (bilgiler != null)
            {
                var claims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Name,p.KullaniciAD),
                         new Claim(ClaimTypes.Role,bilgiler.Rol)
                    };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            }
            else if (bilgiler == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap", "Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult KayitOl(Admin a)
        {
            bool CheckIfUserExist = c.Admins.Where(x => x.KullaniciAD == a.KullaniciAD).Count() != 0;
            if (CheckIfUserExist) ModelState.AddModelError("", "Bu kullanıcı adı zaten kullanılıyor.");
            else if (ModelState.IsValid)
            {
                c.Admins.Add(a);
                c.SaveChanges();
                return RedirectToAction("GirisYap", "Login");
            }
            return View();
        }

        [Authorize(Roles = "O")]
        public IActionResult Adminler()
        {

            var degerler = c.Admins
                   .ToList();
            return View(degerler);
        }

        [Authorize(Roles = "O")]
        public IActionResult Sil(int id)
        {
            if (ModelState.IsValid)
            {
                try
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
            if (ModelState.IsValid)
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
            if (ModelState.IsValid)
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
            bool CheckIfUserExist = c.Admins.Where(x => x.KullaniciAD == a.KullaniciAD && x.ID != a.ID).Count() != 0;
            bool CheckChanges = c.Admins.Where(x => x.KullaniciAD == a.KullaniciAD && x.Sifre == a.Sifre && x.Rol == a.Rol).Count() != 0;
            if (CheckIfUserExist) ModelState.AddModelError("", "Bu kullanıcı adı zaten kullanılıyor.");
            if (CheckChanges) ModelState.AddModelError("", "Düzenleme yapmadınız.");
            if (ModelState.IsValid)
            {
                c.Admins.Update(a);
                c.SaveChanges();
                return RedirectToAction("Adminler");
            }
            return View("Duzenle", c.Admins.Find(a.ID));
        }

        [HttpGet]
        [Authorize(Roles = "O,A")]
        public IActionResult SifreDegis()
        {
            GetUserID();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "O,A")]
        public IActionResult SifreDegis(ChangePass a)
        {
            int id = GetUserID();
            bool CheckOldPass = c.Admins.Where(x => x.ID == id && x.Sifre == a.OldPass).Count() != 0;
            bool CheckNewPassMatch = a.NewPass == a.NewPass2;
            var _admin = new Admin
            {
                ID = id,
                KullaniciAD = this.User.Identity.Name,
                Sifre = a.NewPass,
                Rol = _CurrentUserRole
            };
            if (!CheckOldPass) ModelState.AddModelError("", "Geçerli şifreyi yanlış girdiniz.");
            else if (!CheckNewPassMatch) ModelState.AddModelError("", "Yeni şifre eşleşmiyor.");
            else if (ModelState.IsValid)
            {
                c.Admins.Update(_admin);
                c.SaveChanges();
                return RedirectToAction("CikisYap");
            }
            return View();
        }
    }
}
