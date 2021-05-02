using DAboneTakip.Models;
using DergiAboneProje.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DAboneTakip.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DergiDbContext c = new DergiDbContext();

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]    
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
                
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap", "Login");
        }
        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(Admin a)
        {
            if (ModelState.IsValid)
            {
                c.Admins.Add(a);
                c.SaveChanges();
            }
            return RedirectToAction("GirisYap");
        }
    }

    
}
