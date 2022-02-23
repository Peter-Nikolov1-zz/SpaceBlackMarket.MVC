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
    [Authorize]
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

        public ActionResult Create(int id)
        {
            var service = new ItemService();
            var item = service.GetItemById(id);

            var purchase = new PurchaseItem();

            purchase.ItemId = item.ItemId;
            purchase.ItemName = item.ItemName;
            purchase.ItemPrice = item.ItemPrice;

            return View(purchase);
        }

        public ActionResult CreatePurchase(int id)
        {
            CreatePost(id);
            return RedirectToAction("Index", "Purchase");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void CreatePost(int id)
        { 
            var service = CreatePurchaseService();

            if (service.PurchaseItem(id))
            {
                TempData["SaveResult"] = "Item Purchased, Credits Deducted";
            }

            ModelState.AddModelError("", "Item could not be purchased.");
        }

        public ActionResult Details(int id)
        {
            var service = CreatePurchaseService();
            var model = service.GetPurchaseById(id);

            return View(model);
        }

        private PurchaseService CreatePurchaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            return service;
        }
    }
}