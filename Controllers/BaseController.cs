using Final.EFW.Database;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final.Controllers
{
    public class BaseController : Controller
    {
        internal BaseModel? Model { get; set; }
        internal new string? View {  get; set; }
        public IActionResult UnSecureGet()
        {
            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                Model = new IndexModel(_sessionId, _db);
            }
            if (!System.String.IsNullOrEmpty(Model.sessionId))
            {
                this.Response.Cookies.Append("sessionId", Model.sessionId);
            }
            return View(View, Model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
