using Microsoft.AspNet.Identity;
using SpaceBlackMarket.Models.SpaceTravelerModels;
using SpaceBlackMarket.Services;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    [Authorize]
    public class SpaceTravelerController : Controller
    {
        // GET: SpaceTraveler
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpaceTravelerProfileService(userId);
            var model = service.GetSpaceTravelers();

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
            if (!ModelState.IsValid) return View(model);

            var service = CreateSpaceTravelerService();

            if (service.CreateSpaceTraveler(model)) 
            {
                TempData["SaveResult"] = "Space Traveler Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Space Traveler could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSpaceTravelerService();
            var model = svc.GetSpaceTravelerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSpaceTravelerService();
            var detail = service.GetSpaceTravelerById(id);
            var model =
                new SpaceTravelerEdit
                {
                    SpaceTravelerProfileId = detail.SpaceTravelerProfileId,
                    //OwnerId = detail.OwnerId,
                    TravelerAlias = detail.TravelerAlias,
                    Credits = detail.Credits,
                    WantedLevel = detail.WantedLevel,
                    WillingToCooperate = detail.WillingToCooperate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(int id, SpaceTravelerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.SpaceTravelerProfileId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateSpaceTravelerService();

            if (service.UpdateSpaceTraveler(model))
            {
                TempData["SaveResult"] = "Space Traveler Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Space Traveler could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateSpaceTravelerService();
            var model = svc.GetSpaceTravelerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service =  CreateSpaceTravelerService();

            service.DeleteSpaceTraveler(id);

            TempData["SaveResult"] = "Space Traveler Deleted.";

            return RedirectToAction("Index");
        }

        private SpaceTravelerProfileService CreateSpaceTravelerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpaceTravelerProfileService(userId);
            return service;
        }

    }
}