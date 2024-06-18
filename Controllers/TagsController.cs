using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using Final.Models;
using Final.Static;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;
using static Final.EFW.Database.Core;

namespace Final.Controllers
{
    public class TagsController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        public TagsController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            base.Model = new TagsAddModel();
            View = "/Views/Tags/Add.cshtml";
            return SecureGet(this.RouteData);
        }

        [HttpPost]
        public IActionResult Add(string tagName)
        {
            Hashtable _formRows = new Hashtable
            {
                { "tagName", tagName }
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
