using Final.EFW.Database;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public UsersController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    string? _sessionId = this.Request.Cookies["sessionId"];
        //    if (!System.String.IsNullOrEmpty(_sessionId))
        //    {
        //        Core.DB _db = new Core.DB();
        //        var _RolesAddModel = new RolesAddModel(_sessionId, _db, this.RouteData);
        //        if (_RolesAddModel.Access)
        //        {
        //            return View("/Views/Roles/Add.cshtml", _RolesAddModel);
        //        }
        //        else
        //        {
        //            BaseModel _baseModel = new BaseModel(_sessionId, _db);
        //            return View("/Views/Shared/Deny.cshtml", _baseModel);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Login");
        //    }
        //}

        [HttpGet]
        public IActionResult Modify()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _UsersModifyModel = new UsersModifyModel(_sessionId, _db, this.RouteData);
                if (_UsersModifyModel.Access)
                {
                    return View("/Views/Users/Modify.cshtml", _UsersModifyModel);
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
        public IActionResult Add(string roleName)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _RolesAddModel = new RolesAddModel(_sessionId, _db, roleName, this.RouteData);
                if (_RolesAddModel.Access)
                {
                    return View("/Views/Tags/Add.cshtml", _RolesAddModel);
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
