using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using Final.Models;
using Final.Static;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Final.EFW.Database.Core;

namespace Final.Controllers
{
    public class TagsController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public TagsController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var _TagsAddModel = new TagsAddModel();
            string? _sessionId = this.Request.Cookies["sessionId"];
            Core.DB _db = new Core.DB();
            _TagsAddModel  = new TagsAddModel(_sessionId, _db);
            if (!System.String.IsNullOrEmpty(_sessionId) && _TagsAddModel.accessLevel != null)
            {
                return View("Add", _TagsAddModel);
            }
            else
            {
                var _LoginModel = new LoginModel();
                if (!System.String.IsNullOrEmpty(_sessionId))
                {
                    _LoginModel = new LoginModel(_sessionId, _db);
                }
                if (!System.String.IsNullOrEmpty(_LoginModel.sessionId))
                {
                    this.Response.Cookies.Append("sessionId", _LoginModel.sessionId);
                }
                
                return View("/Views/Login/Login.cshtml", _LoginModel);
            }
        }


        [HttpPost]
        public IActionResult Add(string tagName)
        {
            var _TagsAddModel = new TagsAddModel();
            Core.DB _db = new Core.DB();
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                _TagsAddModel = new TagsAddModel(_sessionId, _db, tagName);
                return View("Add", _TagsAddModel);
            }
            else
            {
                var _LoginModel = new LoginModel();
                if (!System.String.IsNullOrEmpty(_sessionId))
                {
                    _LoginModel = new LoginModel(_sessionId, _db);
                }
                if (!System.String.IsNullOrEmpty(_LoginModel.sessionId))
                {
                    this.Response.Cookies.Append("sessionId", _LoginModel.sessionId);
                }
                return View("/Views/Login/Login.cshtml", _LoginModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
