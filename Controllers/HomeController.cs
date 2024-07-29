using Final.EFW.Database;
using Final.Models;
using Final.Static;
using Final.Static.EntitiesScripts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final.Controllers
{
    public class HomeController : BaseController     
    {
        public IActionResult Index()
        {
            Model = new IndexModel();
            View = "/Views/Home/Index.cshtml";
            return UnSecureGet();
        }
        public IActionResult Exit()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                SessionScripts.End(_sessionId, _db);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
