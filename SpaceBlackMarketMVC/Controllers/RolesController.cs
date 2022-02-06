using Microsoft.AspNet.Identity.EntityFramework;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{ 
    public class RolesController : Controller
    {
        readonly ApplicationDbContext context = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        // GET
        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}