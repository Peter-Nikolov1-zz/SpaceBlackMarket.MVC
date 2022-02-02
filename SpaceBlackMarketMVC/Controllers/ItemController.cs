using Microsoft.AspNet.Identity;
using SpaceBlackMarket.Models.ItemModels;
using SpaceBlackMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            var model = service.GetItems();

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
        public ActionResult Create(ItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateItemService();

            if (service.CreateItem(model))
            {
                TempData["SaveResult"] = "Your item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Item could not be created.");

            return View(model);
        }

        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            return service;
        }
    }
}