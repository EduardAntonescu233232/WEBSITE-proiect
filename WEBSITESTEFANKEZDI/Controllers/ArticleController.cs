using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBSITESTEFANKEZDI.Data;
using WEBSITESTEFANKEZDI.Models;
using Microsoft.AspNetCore.Hosting;
using WEBSITESTEFANKEZDI.ViewModels;
using System.Data.Entity;

namespace WEBSITESTEFANKEZDI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticleController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Create()
        {
            if(HttpContext.Session.GetString("UserName") == "Stefan")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Account");
            }
        }

        [HttpPost]
        public IActionResult Create(ArticleViewModel model)
        {
                if (ModelState.IsValid)
                {
                    var newArticle = new Article
                    {
                        Title = model.Title,
                        Content = model.Content,
                        URL = model.URL,
                        Type = model.ArticleType,
                        Images = new List<ArticleImage>()
                    };

                    foreach (var file in model.Images)
                    {
                        if (file != null && file.Length > 0)
                        {
                            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "article_images", file.FileName);
                            using (var fileStream = new FileStream(imagePath, FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                            }

                            var newImage = new ArticleImage
                            {
                                ImagePath = file.FileName
                            };

                            newArticle.Images.Add(newImage);
                        }
                    }

                    _context.Articles.Add(newArticle);
                    _context.SaveChanges();

                    return RedirectToAction("DashBoard", "Account");
                }
                return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Signin", "Account");
            }

            var articleToDelete = _context.Articles.Find(id);

            if (articleToDelete != null)
            {
                _context.Articles.Remove(articleToDelete);
                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while deleting the article");
            }

            return RedirectToAction("DashBoard", "Account");
        }

        public IActionResult Edit(Guid id)
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                var article = _context.Articles.Find(id);

                if (article != null)
                {
                    var articleViewModel = new ArticleViewModel
                    {
                        Id = article.ArticleId,
                        Title = article.Title,
                        Content = article.Content,
                    };

                    return View(articleViewModel);
                }
                else
                {
                    return RedirectToAction("DashBoard", "Account");
                }
            }
            else
            {
                return RedirectToAction("Signin", "Account");
            }
        }

        [HttpPost]
        public IActionResult Edit(ArticleViewModel art)
        {
            var existingArticle = _context.Articles.Find(art.Id);
            if (ModelState.IsValid)
            {
                if (existingArticle != null)
                {
                    existingArticle.ArticleId = art.Id;
                    existingArticle.Title = art.Title;
                    existingArticle.Content = art.Content;
                    _context.SaveChanges();
                    return RedirectToAction("DashBoard", "Account");
                }
                else
                {
                    return View(art);
                }
            }
            else
            {
                return View(art);
            }
        }

        public IActionResult Details(Guid id)
        {
            var article = _context.Articles.FirstOrDefault(a => a.ArticleId == id);

            if (article == null)
            {
                return NotFound();
            }

            _context.Entry(article).Collection(a => a.Images).Load();
            var firstImage = article.Images.FirstOrDefault();

            var articleDetailsModel = new ArticleDetailsViewModel
            {
                ArticleId = article.ArticleId,
                Title = article.Title,
                Content = article.Content,
                Images = article.Images.Select(img => img.ImagePath).ToList(),
                FirstImagePath = firstImage?.ImagePath
            };

            return View(articleDetailsModel);
        }
    }
}
