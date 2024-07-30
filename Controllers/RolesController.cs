﻿using Final.EFW.Database;
using Final.Models;
using Final.Static;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Diagnostics;
using static Final.EFW.Database.Core;

namespace Final.Controllers
{
    public class RolesController : Controller
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IActionResult Add()
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));

            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _RolesAddModel = new RolesAddModel(_sessionId, _db, this.RouteData);
                if (_RolesAddModel.Access)
                {
                    return View("/Views/Roles/Add.cshtml", _RolesAddModel);
                }
                else
                {
                    BaseModel _baseModel = new BaseModel(_sessionId, _db);
                    return View("/Views/Shared/Deny.cshtml", _baseModel);
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpGet]
        public IActionResult Modify()
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | id: {3} | sessionId: {4}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.RouteData.Values["id"].ToString(), this.Request.Cookies["sessionId"]));

            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _RolesModifyModel = new RolesModifyModel(_sessionId, _db, this.RouteData);
                if (_RolesModifyModel.Access)
                {
                    return View("/Views/Roles/Modify.cshtml", _RolesModifyModel);
                }
                else
                {
                    BaseModel _baseModel = new BaseModel(_sessionId, _db);
                    return View("/Views/Shared/Deny.cshtml", _baseModel);
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


        [HttpPost]
        public IActionResult Add(string roleName)
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));

            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _RolesAddModel = new RolesAddModel(_sessionId, _db, roleName, this.RouteData);
                if (_RolesAddModel.Access)
                {
                    return View("/Views/Roles/Add.cshtml", _RolesAddModel);
                }
                else
                {
                    BaseModel _baseModel = new BaseModel(_sessionId, _db);
                    return View("/Views/Shared/Deny.cshtml", _baseModel);
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult Modify(string RoleName, string RoleDescription)
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | id: {3} | sessionId: {4}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.RouteData.Values["id"].ToString(), this.Request.Cookies["sessionId"]));

            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _RolesModifyModel = new RolesModifyModel(_sessionId, _db, this.RouteData);
                if (_RolesModifyModel.Access)
                {
                    _RolesModifyModel.ChangeRole(_db, this.RouteData, RoleName, RoleDescription);
                    return View("/Views/Roles/Modify.cshtml", _RolesModifyModel);
                }
                else
                {
                    BaseModel _baseModel = new BaseModel(_sessionId, _db);
                    return View("/Views/Shared/Deny.cshtml", _baseModel);
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpGet]
        public IActionResult All()
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));

            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _RolesAllModel = new RolesAllModel(_sessionId, _db, this.RouteData);
                if (_RolesAllModel.Access)
                {
                    return View("/Views/Roles/All.cshtml", _RolesAllModel);
                }
                else
                {
                    BaseModel _baseModel = new BaseModel(_sessionId, _db);
                    return View("/Views/Shared/Deny.cshtml", _baseModel);
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

