using Final.EFW.Entities;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net;

namespace Final.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            CookieBuilder _cookie = new CookieBuilder();
            _cookie.Build(HttpContent);
            cookie.Values["CompanyID"] = Convert.ToString(CompanyId);
            Response.SetCookie(cookie); //SetCookie() is used for update the cookie.
            Response.Cookies.Add(cookie);
            Header _header = new Header();
            return View(_header);
        }
        [HttpPost]
        public IActionResult Register(string login, string password)
        {
            CookieBuilder _cookie = new CookieBuilder();
            _cookie.Build(HttpContext);
            Header _header = new Header(login, password, _cookie);
            return View(_header);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
