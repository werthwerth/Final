using Final.EFW.Database;
using Final.Models;
using Final.Static;
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
    }
}
