using Final.EFW.Database;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static Final.EFW.Database.Core;

namespace Final.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController>? logger;
        internal BaseModel? Model { get; set; }
        internal new string? View { get; set; }
        public IActionResult UnSecureGet(RouteData? _RouteData = null)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            Core.DB _db = new Core.DB();
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                if (_RouteData == null)
                {
                    Model.Init(_sessionId, _db);
                }
                else
                {
                    Model.Init(_sessionId, _db, _RouteData);
                }
            }
            if (Model.isLogged)
            {
                if (!System.String.IsNullOrEmpty(Model.sessionId))
                {
                    this.Response.Cookies.Append("sessionId", Model.sessionId);
                }
                return View(View, Model);
            }
            else
            {
                BaseModel _baseModel = new BaseModel(_sessionId, _db);
                return RedirectToAction("Login", "Login");
            }
        }
        public IActionResult UnSecurePost(RouteData _RouteData, Hashtable _Hashtable)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            Core.DB _db = new Core.DB();
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                if (_RouteData == null)
                {
                    Model.Init(_sessionId, _db);
                }
                else
                {
                    Model.Init(_sessionId, _db, _RouteData);
                }
            }
            if (Model.isLogged)
            {
                if (!System.String.IsNullOrEmpty(Model.sessionId))
                {
                    this.Response.Cookies.Append("sessionId", Model.sessionId);
                }
                Model.Exec(_sessionId, _db, _RouteData, _Hashtable);
                return View(View, Model);
            }
            else
            {
                BaseModel _baseModel = new BaseModel(_sessionId, _db);
                return RedirectToAction("Login", "Login");
            }

        }
        public IActionResult SecureGet(RouteData _RouteData)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                Model.GetAccess(_sessionId, _db, _RouteData);
                if (Model.Access)
                {
                    return View(View, Model);
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
        public IActionResult SecurePost(RouteData _RouteData, Hashtable _Hashtable)
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                Model.GetAccess(_sessionId, _db, _RouteData);
                if (Model.Access)
                {
                    Model.Exec(_sessionId, _db, _RouteData, _Hashtable);
                    return View(View, Model);
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
