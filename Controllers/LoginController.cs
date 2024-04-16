using Final.EFW.Database;
using Final.Models;
using Final.Static;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
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
            return View(_LoginModel);
        }
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            Core.DB _db = new Core.DB();
            string? _sessionId = this.Request.Cookies["sessionId"];
            LoginModel _LoginModel = new LoginModel(login, password, _db);
            if (!System.String.IsNullOrEmpty(_LoginModel.sessionId))
            {
                this.Response.Cookies.Append("sessionId", _LoginModel.sessionId);
            }
            return View(_LoginModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
