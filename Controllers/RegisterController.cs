using Final.EFW.Entities;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Final.Static;
using Final.EFW.Database;
using NLog;

namespace Final.Controllers
{

    public class RegisterController : Controller
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        [HttpGet]
        public IActionResult Register()
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));

            var _RegisterModel = new RegisterModel();
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            { 
                Core.DB _db = new Core.DB();
                _RegisterModel = new RegisterModel(_sessionId, _db);
            }
            if (!System.String.IsNullOrEmpty(_RegisterModel.sessionId))
            {
                this.Response.Cookies.Append("sessionId", _RegisterModel.sessionId);
            }
            return View(_RegisterModel);
        }
        [HttpPost]
        public IActionResult Register(string login, string password, string firstName, string lastName, string email)
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));

            Core.DB _db = new Core.DB();
            string? _sessionId = this.Request.Cookies["sessionId"];
            RegisterModel _RegisterModel = new RegisterModel(login, password, firstName, lastName, email, _db, _sessionId);
            if (!System.String.IsNullOrEmpty(_RegisterModel.sessionId))
            {
                this.Response.Cookies.Append("sessionId", _RegisterModel.sessionId);
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
