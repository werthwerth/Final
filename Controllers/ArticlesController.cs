using Final.EFW.Database;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public ArticlesController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _ArticlesAddModel = new ArticlesAddModel(_sessionId, _db, this.RouteData);
                return View("/Views/Articles/Add.cshtml", _ArticlesAddModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult Add(string tagName)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                ArticlesAddModel _ArticlesAddModel = new ArticlesAddModel(_sessionId, _db, tagName, this.RouteData);
                return View("/Views/Articles/Add.cshtml", _ArticlesAddModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
