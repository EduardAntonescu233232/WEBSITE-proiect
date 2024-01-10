using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WEBSITESTEFANKEZDI.Data;
using WEBSITESTEFANKEZDI.Data.Migrations;
using WEBSITESTEFANKEZDI.Models;
using WEBSITESTEFANKEZDI.ViewModels;

namespace WEBSITESTEFANKEZDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrainMotion()
        {
            List<TMModellingArticleViewModel> articleModels = new List<TMModellingArticleViewModel>();

            if (_dbContext != null)
            {
                var articles = _dbContext.Articles.Include(a => a.Images).ToList();

                foreach (var article in articles)
                {
                    var imagePaths = article.Images.Select(image => image.ImagePath).ToList();

                    TMModellingArticleViewModel articleModel = new TMModellingArticleViewModel
                    {
                        ArticleId = article.ArticleId,
                        Title = article.Title,
                        Content = article.Content,
                        URL = article.URL,
                        Type = (int)article.Type,
                        Images = imagePaths
                    };

                    articleModels.Add(articleModel);
                }

                return View(articleModels);
            }
            else
            {
                ViewBag.Message = "No articles.";
                return View();
            }
        }

        public IActionResult Modelling()
        {
            List<TMModellingArticleViewModel> articleModels = new List<TMModellingArticleViewModel>();

            if (_dbContext != null)
            {
                var articles = _dbContext.Articles.Include(a => a.Images).ToList();

                foreach (var article in articles)
                {
                    var imagePaths = article.Images.Select(image => image.ImagePath).ToList();

                    TMModellingArticleViewModel articleModel = new TMModellingArticleViewModel
                    {
                        ArticleId = article.ArticleId,
                        Title = article.Title,
                        Content = article.Content,
                        URL = article.URL,
                        Type = (int)article.Type,
                        Images = imagePaths
                    };

                    articleModels.Add(articleModel);
                }

                return View(articleModels);
            }
            else
            {
                ViewBag.Message = "No articles.";
                return View();
            }
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}