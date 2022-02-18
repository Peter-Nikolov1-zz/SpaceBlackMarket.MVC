using Microsoft.AspNet.Identity;
using SpaceBlackMarket.Models.ItemModels;
using SpaceBlackMarket.Services;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SpaceBlackMarketMVC.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService();
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

        public ActionResult Details(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = new ItemService();
            var detail = service.GetItemById(id);
            var model =
                new ItemEdit
                {
                    ItemId = detail.ItemId,
                    ItemName = detail.ItemName,
                    ItemPrice = detail.ItemPrice,
                    ItemDescription = detail.ItemDescription,
                    ItemType = detail.ItemType,
                    SmuggleDelivery = detail.SmuggleDelivery
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateItemService();

            if (service.UpdateItem(model))
            {
                TempData["SaveResult"] = "Your Item was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your item could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateItemService();

            service.DeleteItem(id);

            TempData["SaveResult"] = "Your Item was deleted.";

            return RedirectToAction("Index");
        }
    }
}