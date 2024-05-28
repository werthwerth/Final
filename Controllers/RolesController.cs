using Final.EFW.Database;
using Final.Models;
using Final.Static;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Final.EFW.Database.Core;

namespace Final.Controllers
{
    public class RolesController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public RolesController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            Core.DB _db = new Core.DB();
            RolesAddModel _RolesAddModel = new RolesAddModel(_sessionId, _db);
            if (!System.String.IsNullOrEmpty(_sessionId) && _RolesAddModel.accessLevel < 3)
            {
                return View("Add", _RolesAddModel);
            }
            else
            {
                BaseModel _baseModel = new BaseModel(_sessionId, _db);
                return View("/Views/Shared/Deny.cshtml", _baseModel);
            }
        }


        [HttpPost]
        public IActionResult Add(string roleName)
        {
            var _RolesAddModel = new RolesAddModel();
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                _RolesAddModel = new RolesAddModel(_sessionId, _db, roleName);
                return View("Add", _RolesAddModel);
            }

            else
            {
                return View("/Views/Shared/Deny.cshtml", _RolesAddModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

