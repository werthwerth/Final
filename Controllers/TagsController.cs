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
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _TagsAddModel = new TagsAddModel(_sessionId, _db, this.RouteData);
                if (_TagsAddModel.Access)
                {
                    return View("/Views/Tags/Add.cshtml", _TagsAddModel);
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
        public IActionResult Add(string tagName)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                TagsAddModel _TagsAddModel = new TagsAddModel(_sessionId, _db, tagName, this.RouteData);
                if (_TagsAddModel.Access)
                {
                    return View("/Views/Tags/Add.cshtml", _TagsAddModel);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
