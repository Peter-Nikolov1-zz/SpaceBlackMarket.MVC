﻿using SpaceBlackMarket.Models.OutpostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    [Authorize]
    public class OutpostController : Controller
    {
        // GET: Outpost
        public ActionResult Index()
        {
            var model = new OutpostList[0];
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OutpostList model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
        
    }
}