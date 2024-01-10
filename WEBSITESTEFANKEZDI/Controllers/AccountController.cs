using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System.Data.Entity.Validation;
using WEBSITESTEFANKEZDI.Data;
using WEBSITESTEFANKEZDI.Data.Migrations;
using WEBSITESTEFANKEZDI.Models;
using WEBSITESTEFANKEZDI.ViewModels;

namespace WEBSITESTEFANKEZDI.Controllers
{

    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel account)
        {
            if (_context.Accounts.Any(x => x.UserName == account.UserName))
            {
                ModelState.AddModelError("UserName", "This username already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(account);
            }

            if (!account.Password.Equals(account.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords don't match, try again!");
                return View(account);
            }

            var newAccount = new Models.Account
            {
                AccountId = account.AccountId,
                UserName = account.UserName,
                Email = account.Email,
                Password = account.Password,
                ConfirmPassword = account.ConfirmPassword
            };

            _context.Accounts.Add(newAccount);
            _context.SaveChanges();

            HttpContext.Session.SetString("Id", account.AccountId.ToString());
            HttpContext.Session.SetString("Username", account.UserName);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signin(LoginViewModel login)
        {
            var checkLogin = _context.Accounts.FirstOrDefault(x => x.UserName.Equals(login.UserName));

            if (login.UserName == "Stefan" && login.Password == "Admin")
            {
                HttpContext.Session.SetString("Id", login.Id.ToString());
                HttpContext.Session.SetString("UserName", login.UserName);
                return RedirectToAction("DashBoard", "Account");
            }
            return View();
        }

        public IActionResult DashBoard()
        {
            List<ArticleViewModel> articlemodels = new List<ArticleViewModel>();


            if (HttpContext.Session.GetString("UserName") == "Stefan")
            {
                var articles = _context.Articles.ToList(); 

                foreach (var article in articles)
                {
                    ArticleViewModel articlemodel = new ArticleViewModel
                    {
                        Id = article.ArticleId,
                        Title = article.Title,
                        Content = article.Content
                    };

                    articlemodels.Add(articlemodel);
                }
                return View(articlemodels);
            }
            else
            {
                return RedirectToAction("Signin", "Account");
            }
        }
    }
}

