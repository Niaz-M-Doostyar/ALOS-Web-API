using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
using ALOS_Web_Admin.Models.Api.DbModels;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Http;

namespace ALOS_Web_Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly alosapiContext _context;

        public AccountController(alosapiContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(
            ErrorMessage = "Please Enter Valid Captcha",
            CaptchaGeneratorLanguage = Language.English,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)]
        public async Task<IActionResult> Login(Users users)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Agents.FirstOrDefault(u => u.Email.Equals(users.Email) && u.Password.Equals(users.Password));

                if (result != null)
                {
                    HttpContext.Session.SetString("User", result.Name);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                    ViewBag.errorMessage = "Username or Password is not Correct";
            }
            return View(users);
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.SetString("User", String.Empty);
            return View("Login");
        }
    }
}
