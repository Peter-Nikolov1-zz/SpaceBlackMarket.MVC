using Microsoft.AspNet.Identity;
using SpaceBlackMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    public class SpaceTravelerProfilePageController : Controller
    {
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

        private SpaceTravelerProfileService CreateSpaceTravelerProfilePage()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpaceTravelerProfileService(userId);
            return service;
        }
    }
}