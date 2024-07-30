using Final.EFW.Database;
using Final.Models;
using Final.Static;
using Final.Static.EntitiesScripts;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Diagnostics;

namespace Final.Controllers
{
    public class HomeController : BaseController     
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        public IActionResult Index()
        {
            Model = new IndexModel();
            View = "/Views/Home/Index.cshtml";
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));
            return UnSecureGet();
        }
        public IActionResult Exit()
        {
            
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));
            return UnSecureGet();
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
