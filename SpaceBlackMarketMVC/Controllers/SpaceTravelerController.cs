using SpaceBlackMarket.Models.SpacePirateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    public class SpaceTravelerController : Controller
    {
        // GET: SpaceTraveler
        public ActionResult Index()
        {
            var model = new SpaceTravelerList();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }
    }
}