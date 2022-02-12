using Microsoft.AspNet.Identity;
using SpaceBlackMarket.Models.ProfilePage;
using SpaceBlackMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    [Authorize]
    public class SpaceTravelerProfilePageController : Controller
    {
        private SpaceTravelerProfileService CreateSpaceTravelerProfilePage()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpaceTravelerProfileService(userId);
            return service;
        }

        // GET: SpaceTravelerProfilePage
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpaceTravelerProfileService(userId);
            var model = service.GetTravelerProfilePage();

            return View(model);
        }

        public ActionResult TravelerProfile(int id)
        {
            var svc = CreateSpaceTravelerProfilePage();
            var model = svc.GetSpaceTravelerProfilePageById(id);

            return View(model);
        }

        public ActionResult EditProfile(int id)
        {
            var service = CreateSpaceTravelerProfilePage();
            var detail = service.GetSpaceTravelerProfilePageById(id);
            var model =
                new ProfileEdit
                {
                    SpaceTravelerProfileId = detail.SpaceTravelerProfileId,
                    TravelerAlias = detail.TravelerAlias,
                    Credits = detail.Credits,
                    WantedLevel = detail.WantedLevel,
                    WillingToCooperate = detail.WillingToCooperate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(int id, ProfileEdit model)
        {
            if(!ModelState.IsValid) return View(model);

            if(model.SpaceTravelerProfileId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSpaceTravelerProfilePage();

            if (service.UpdateProfilePage(model))
            {
                TempData["SaveResult"] = "Profile Updated";
                return RedirectToAction("Index", "HomeController");
            }

            ModelState.AddModelError("", "Profile Could Not Be Updated");
            return View();
        }
        
    }
}