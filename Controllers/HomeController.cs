using Final.EFW.Database;
using Final.Models;
using Final.Static;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        public IActionResult Index()
        {
            var _IndexModel = new IndexModel();
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                _IndexModel = new IndexModel(_sessionId, _db);
            }
            if (!System.String.IsNullOrEmpty(_IndexModel.sessionId))
            {
                this.Response.Cookies.Append("sessionId", _IndexModel.sessionId);
            }
            return View("Index", _IndexModel);
        }
        public IActionResult Roles()
        {
            var _IndexModel = new IndexModel();
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                _IndexModel = new IndexModel(_sessionId, _db);
            }
            if (_IndexModel.accessLevel != null && _IndexModel.accessLevel <= 2)
            {
                return View("Roles", _IndexModel);
            }
            else
            {
                if (!System.String.IsNullOrEmpty(_IndexModel.sessionId))
                {
                    this.Response.Cookies.Append("sessionId", _IndexModel.sessionId);
                }
                return View("Deny", _IndexModel);
            }
        }


        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Exit()
        {
            ExitModel _ExitModel = new ExitModel();
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                _ExitModel = new ExitModel(_sessionId, _db);
                this.Response.Cookies.Delete("sessionId");
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
