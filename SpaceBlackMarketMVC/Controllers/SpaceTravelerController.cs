using SpaceBlackMarket.Models.SpaceTravelerModels;
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
            var model = new SpaceTravelerList[0];
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
        public ActionResult Create(SpaceTravelerCreate model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }

        
    }
}