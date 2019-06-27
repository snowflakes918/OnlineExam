using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Exam.BOL.Entities;
using Exam.DAL.Repositories;
using Exam.WebUI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.WebUI.Controllers
{

    public class HomeController : Controller
    {
        ISqlRepository<User> repoUser;
        public HomeController(ISqlRepository<User> _repoUser)
        {
            repoUser = _repoUser;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = repoUser.GetBy(g => g.username == model.username && g.password == model.password);
            if (user == null)
            {
                ViewBag.LoginError = "Kullanıcı adı veya şifre yanlış";
            }
            else
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.username)
                    };
                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Exams");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}