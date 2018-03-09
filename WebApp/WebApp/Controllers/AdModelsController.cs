using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Repo.Models;

namespace WebApp.Controllers
{
    public class AdModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: AdModels/Create
        [Authorize]
        public ActionResult Index()
        {
            ApplicationUser applicationUser = db.ApplicationUsers.Find(User.Identity.GetUserId());
            using (db)
            {
                var query = db.Ads
                                   .Where(s => s.ApplicationUser.Id == applicationUser.Id )
                                   .FirstOrDefault<AdModel>();
                if(query != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        // POST: AdModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Index([Bind(Include = "Type,ImagePath,Area,ShortDescription,Skills,Links")] AdModel adModel)
        {
            ApplicationUser applicationUser = db.ApplicationUsers.Find(User.Identity.GetUserId());
            adModel.ApplicationUser = applicationUser;

            if (ModelState.IsValid)
            {
                db.Ads.Add(adModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(adModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
