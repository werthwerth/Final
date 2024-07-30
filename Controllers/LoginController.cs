using Final.EFW.Database;
using Final.Models;
using Final.Static;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Diagnostics;

namespace Final.Controllers
{
    public class LoginController : Controller
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        [HttpGet]
        public IActionResult Login()
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));

            var _LoginModel = new LoginModel();
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                _LoginModel = new LoginModel(_sessionId, _db);
            }
            if (!System.String.IsNullOrEmpty(_LoginModel.sessionId))
            {
                this.Response.Cookies.Append("sessionId", _LoginModel.sessionId);
            }
            return View("Login", _LoginModel);
        }
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));

            Core.DB _db = new Core.DB();
            string? _sessionId = this.Request.Cookies["sessionId"];
            LoginModel _LoginModel = new LoginModel(login, password, _db);
            if (!System.String.IsNullOrEmpty(_LoginModel.sessionId))
            {
                this.Response.Cookies.Append("sessionId", _LoginModel.sessionId);
            }
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
