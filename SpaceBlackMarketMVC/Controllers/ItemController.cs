using SpaceBlackMarket.Models.ItemModels;
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
            var model = new ItemsList[0];
            return View(model);
        }
    }
}