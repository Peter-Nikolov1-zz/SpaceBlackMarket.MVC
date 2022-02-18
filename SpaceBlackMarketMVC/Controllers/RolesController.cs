using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlackMarketMVC.Controllers
{
    [Authorize(Roles = "Admin")]
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
            if(role == null)
            {
                return View(role);
            }
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(IdentityRole role)
        {
            context.Roles.Remove(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}