using SpaceBlackMarket.Data;
using SpaceBlackMarket.Models.TransactionModels;
using SpaceBlackMarket.Services;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    public class TransactionController : Controller
    {
        [Authorize]
        private TransactionService CreateTransactionService()
        {
            var service = new TransactionService();
            return service;
        }

        // GET: Transaction
        public ActionResult Transaction()
        {
            var service = new ItemService();
            var itemList = service.GetItems();
            return View(itemList);
        }

        public ActionResult CreateTransaction()
        {
            List<Item> items;
            using (var ctx = new ApplicationDbContext())
            {
                items = ctx.Items.ToList();
            }
            ViewBag.Items = new SelectList(items, "ItemId", "ItemName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTransaction(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionService();

            if (service.Create(model))
            {
                TempData["SaveResult"] = "Transaction Created.";
                return RedirectToAction("Transaction");
            }

            ModelState.AddModelError("", "Transaction could not be created.");

            return View(model);
        }


    }
}