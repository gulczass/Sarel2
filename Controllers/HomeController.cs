using Microsoft.AspNetCore.Mvc;
using sarel.Models;
using System.Diagnostics;

namespace sarel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleService _articleService;

        public HomeController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Articles()
        {
            var articles = _articleService.GetAllArticles();
            return View(articles);
        }

        public IActionResult Index()
        {
            var articles = _articleService.GetAllArticles();
            return View(articles);
        }

        public IActionResult ArticleDetails(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        public IActionResult Privacy()
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
