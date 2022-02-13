using SpaceBlackMarket.Models.TransactionModels;
using SpaceBlackMarket.Services;
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

        private ItemService CreateItemService()
        {
            var service = new ItemService();
            var itemList = service.GetItems();
            return service;
        }
        // GET: Transaction
        public ActionResult Transaction()
        {
            var service = new ItemService();
            var itemList = service.GetItems();
            return View(itemList);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(TransactionCreate model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var service = CreateItemService();

        //}
    }
}