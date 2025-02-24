﻿using InstApp.Util.Common;
using OrgWebMvc.Main.Service;
using OrgWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrgWebMvc.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (!UserValid())
            {
                return RedirectToAction("Index", "Home");
            }

            EventService EventSvc = new EventService();
            Dictionary<string, object> Params = new Dictionary<string, object>();
            DateTime Now = DateTime.Now;
            Params.Add("date.day", Now.Day);
            Params.Add("date.year", Now.Year);
            Params.Add("date.month", Now.Month);
            Params.Add("user_id", LoggedUser.id);

            List<@event> ToDayEvents = (List<@event>)ObjectUtil.ConvertList(EventSvc.SearchAdvanced(Params, 10), typeof(List<@event>));
            ViewData["TodayEvents"] = ToDayEvents;

            return View();
        }

        public ActionResult Stucture()
        {
            if (!base.UserValid())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
