using DAboneTakip.Models;
using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DAboneTakip.Controllers
{
    
    public class LoginController : Controller
    {
        readonly DergiDbContext c = new DergiDbContext();
       
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
                else
                {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                return View();
                }
            
            return RedirectToAction("Index", "Home");
        }
        public int GetUserID() //Giriş yapmış kullanıcının idsini alır
        {
            if (User.Identity.IsAuthenticated)
            {
                string a = this.User.Identity.Name;
                int uid = c.Admins.Where(x => x.KullaniciAD == a).Select(x => x.ID).FirstOrDefault();               
                return uid;
            }
            return -1;
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
            if (ModelState.IsValid)
            {
                c.Admins.Add(a);
                c.SaveChanges();
            }
            return RedirectToAction("GirisYap", "Login");
        }
        public bool CheckIfOwner(int id)
        {
            var a = c.Admins.Find(id);
            if (a.Rol == "O") return true;
            return false;
        }
        [Authorize(Roles = "O")]
        public IActionResult Adminler()
        {
           
            var degerler = c.Admins
                   .ToList();
            return View(degerler);
        }
        [Authorize(Roles = "O")]
        public IActionResult AdminYap(int id)
        {
            if (!CheckIfOwner(id))
            {
                try
                {
                    var acc = c.Admins.Find(id);
                    acc.Rol = "A";
                    c.Admins.Update(acc);
                    c.SaveChanges();
                }
                catch
                {

                }
            }
            
            return RedirectToAction("Adminler");
        }
        [Authorize(Roles = "O")]
        public IActionResult UserYap(int id)
        {
            if (!CheckIfOwner(id))
            {
                try
                {
                    var acc = c.Admins.Find(id);
                    acc.Rol = "U";
                    c.Admins.Update(acc);
                    c.SaveChanges();
                }
                catch
                {

                }
            }
            return RedirectToAction("Adminler");
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
                    //return RedirectToAction("Liste");
                }
                catch
                {

                }
            }
            return NoContent();
        }
        //public IActionResult AdminEkle()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Bilgiler()
        //{
        //    int id = GetUserID();
        //    if (id != -1)
        //    {
        //        var bilgiler = c.Admins.Find(id);
        //        return View("Bilgiler", bilgiler); 
        //    }
        //    return NoContent();
        //}
        //[HttpPost]
        //public IActionResult Bilgiler(Admin a)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        c.Admins.Update(a);
        //        c.SaveChanges();
        //    }
        //    return View();
        //}
    }

}
