using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using Final.EFW.Entities;
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
        [HttpGet]
        public IActionResult Modify()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _ArticlesModifyModel = new ArticlesModifyModel(_sessionId, _db, this.RouteData);
                if (_ArticlesModifyModel.Access)
                {
                    return View("/Views/Articles/Modify.cshtml", _ArticlesModifyModel);
                }
                else
                {
                    BaseModel _baseModel = new BaseModel(_sessionId, _db);
                    return View("/Views/Shared/Deny.cshtml", _baseModel);
                }
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
                foreach (var _tag in this.Request.Form)
                {
                    if (Guid.TryParse(_tag.Key, out var _out) && _tag.Value[0] == "true")
                    {
                        var _tempTag = TagEntity.GetById(_db, _tag.Key);
                        if (_tempTag != null)
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

        [HttpPost]
        public IActionResult Modify(string ArticleSubject, string ArticleText)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                List<Tag> _tagList = new List<Tag>();
                foreach (var _tag in this.Request.Form)
                {
                    if (Guid.TryParse(_tag.Key, out var _out) && _tag.Value[0] == "true")
                    {
                        var _tempTag = TagEntity.GetById(_db, _tag.Key);
                        if (_tempTag != null)
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

        [HttpGet]
        public IActionResult All()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _ArticlesAllModel = new ArticlesAllModel(_sessionId, _db, this.RouteData);
                return View("/Views/Articles/All.cshtml", _ArticlesAllModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _ArticlesDeleteModel = new ArticlesDeleteModel(_sessionId, _db, this.RouteData);
                return RedirectToAction("All", "Articles");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpGet]
        public IActionResult View()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _ArticlesViewModel = new ArticlesViewModel(_sessionId, _db, this.RouteData);
                return View("/Views/Articles/View.cshtml", _ArticlesViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public IActionResult View(string CommentText)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _ArticlesViewModel = new ArticlesViewModel(_sessionId, _db, this.RouteData, CommentText);
                return View("/Views/Articles/View.cshtml", _ArticlesViewModel);
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
