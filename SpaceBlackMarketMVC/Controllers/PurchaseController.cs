using Microsoft.AspNet.Identity;
using SpaceBlackMarket.Data;
using SpaceBlackMarket.Models.PurchaseModels;
using SpaceBlackMarket.Services;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            var model = service.GetPurchases();

            return View(model);
        }

        public ActionResult CreateAPurchase()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAPurchase(int id, PurchaseItem model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ItemId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreatePurchaseService();

            if (service.PurchaseItem(model))
            {
                TempData["SaveResult"] = "Item Purchased";
                return RedirectToAction("Index", "Item");
            }

            ModelState.AddModelError("", "Item could not be purchased.");
            return View();
        }

        private PurchaseService CreatePurchaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            return service;
        }
    }
}