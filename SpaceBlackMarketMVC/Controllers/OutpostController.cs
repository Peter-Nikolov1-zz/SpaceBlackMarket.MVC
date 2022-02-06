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

        public ActionResult Edit(int id)
        {
            var service = new OutpostService();
            var detail = service.GetOutpostById(id);
            var model =
                new OutpostEdit
                {
                    OutpostId = detail.OutpostId,
                    OutpostName = detail.OutpostName,
                    GalaxyName = detail.GalaxyName,
                    PlanetName = detail.PlanetName,
                    DangerLevel = detail.DangerLevel
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OutpostEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.OutpostId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(model);
            }

            var service = new OutpostService();

            if (service.UpdateOutpost(model))
            {
                TempData["SaveResult"] = "Outpost has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Outpost could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new OutpostService();
            var model = svc.GetOutpostById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new OutpostService();

            service.DeleteOutpost(id);

            TempData["SaveResult"] = "Outpost Deleted.";

            return RedirectToAction("Index");
        }

    }
}