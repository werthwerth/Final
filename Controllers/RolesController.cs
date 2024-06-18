using Final.EFW.Database;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;
using static Final.EFW.Database.Core;

namespace Final.Controllers
{
    public class RolesController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        public RolesController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            base.Model = new RolesAddModel();
            View = "/Views/Roles/Add.cshtml";
            return SecureGet(this.RouteData);
        }

        [HttpPost]
        public IActionResult Add(string roleName)
        {
            Hashtable _formRows = new Hashtable
            {
                { "roleName", roleName }
            };
            base.Model = new RolesAddModel();
            View = "/Views/Roles/Add.cshtml";
            return SecurePost(this.RouteData, _formRows);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

