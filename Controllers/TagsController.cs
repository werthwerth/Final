﻿using Final.EFW.Database;
using Final.EFW.Database.EntityActions;
using Final.Models;
using Final.Static;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Diagnostics;
using static Final.EFW.Database.Core;

namespace Final.Controllers
{
    public class TagsController : Controller
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
                var _TagsAddModel = new TagsAddModel(_sessionId, _db, this.RouteData);
                if (_TagsAddModel.Access)
                {
                    return View("/Views/Tags/Add.cshtml", _TagsAddModel);
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
        public IActionResult Add(string tagName)
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | sessionId: {3}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.Request.Cookies["sessionId"]));

            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                TagsAddModel _TagsAddModel = new TagsAddModel(_sessionId, _db, tagName, this.RouteData);
                if (_TagsAddModel.Access)
                {
                    return View("/Views/Tags/Add.cshtml", _TagsAddModel);
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
                var _TagsModifyddModel = new TagsModifyModel(_sessionId, _db, this.RouteData);
                if (_TagsModifyddModel.Access)
                {
                    return View("/Views/Tags/Modify.cshtml", _TagsModifyddModel);
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
        public IActionResult Modify(string TagText)
        {
            logger.Debug(string.Format("method: {0} | controller: {1} | action: {2} | id: {3} | sessionId: {4}", this.Request.Method, this.RouteData.Values["controller"].ToString(), this.RouteData.Values["action"].ToString(), this.RouteData.Values["id"].ToString(), this.Request.Cookies["sessionId"]));

            string? _sessionId = this.Request.Cookies["sessionId"];
            if (!System.String.IsNullOrEmpty(_sessionId))
            {
                Core.DB _db = new Core.DB();
                var _TagsModifyddModel = new TagsModifyModel(_sessionId, _db, TagText, this.RouteData);
                if (_TagsModifyddModel.Access)
                {
                    return View("/Views/Tags/Modify.cshtml", _TagsModifyddModel);
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
                var _TagsAllModel = new TagsAllModel(_sessionId, _db, this.RouteData);
                if (_TagsAllModel.Access)
                {
                    return View("/Views/Tags/All.cshtml", _TagsAllModel);
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
