using Final.EFW.Database;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Final.EFW.Entities;
using Final.EFW.Database.EntityActions;
using System.Linq;

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
        public IActionResult Add(string ArticleSubject, string ArticleText)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                List<Tag> _tagList = new List<Tag>();
                foreach(var _tag in this.Request.Form)
                {
                    if (Guid.TryParse(_tag.Key, out var _out) && _tag.Value[0] == "true")
                    {
                        var _tempTag = TagEntity.GetById(_db, _tag.Key);
                        if(_tempTag != null)
                        {
                            _tagList.Add(_tempTag);
                        }
                    }
                }
                ArticlesAddModel _ArticlesAddModel;
                if (ArticleSubject != null && ArticleText != null)
                {
                    if (_tagList.Count > 0)
                    {
                        _ArticlesAddModel = new ArticlesAddModel(_sessionId, _db, this.RouteData, _tagList, ArticleSubject, ArticleText);
                    }
                    else
                    {
                        _ArticlesAddModel = new ArticlesAddModel(_sessionId, _db, this.RouteData, ArticleSubject, ArticleText);
                    }
                }
                else
                {
                    _ArticlesAddModel = new ArticlesAddModel(_sessionId, _db, this.RouteData);
                }
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
