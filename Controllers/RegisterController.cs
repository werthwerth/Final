using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            Header _header = new Header();
            return View(_header);
        }
        [HttpPost]
        public IActionResult Register(string login, string password)
        {
            Header _header = new Header(login, password);
            return View(_header);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
