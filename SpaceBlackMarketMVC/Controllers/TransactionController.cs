using SpaceBlackMarket.Models.TransactionModels;
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
        // GET: Transaction
        public ActionResult Index()
        {
            var model = new TransactionList[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(TransactionCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}