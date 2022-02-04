using SpaceBlackMarket.Models.OutpostModels;
using SpaceBlackMarket.Services;
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
            var service = new OutpostService();
            var model = service.GetOutposts();
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
        public ActionResult Create(OutpostCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new OutpostService();

            if (service.CreateOutpost(model))
            {
                TempData["SaveResult"] = "Outpost Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Outpost could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = new OutpostService();
            var model = svc.GetOutpostById(id);

            return View(model);
        }
        
    }
}