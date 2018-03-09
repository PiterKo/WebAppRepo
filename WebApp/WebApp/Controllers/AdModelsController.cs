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

        // GET: AdModels
        public ActionResult Index()
        {
            return View(db.Ads.ToList());
        }

        // GET: AdModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModel adModel = db.Ads.Find(id);
            if (adModel == null)
            {
                return HttpNotFound();
            }
            return View(adModel);
        }

        // GET: AdModels/Create
        [Authorize]
        public ActionResult Create()
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
        public ActionResult Create([Bind(Include = "Type,ImagePath,Area,ShortDescription,Skills,Links")] AdModel adModel)
        {
            ApplicationUser applicationUser = db.ApplicationUsers.Find(User.Identity.GetUserId());
            adModel.ApplicationUser = applicationUser;

            if (ModelState.IsValid)
            {
                db.Ads.Add(adModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adModel);
        }

        // GET: AdModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModel adModel = db.Ads.Find(id);
            if (adModel == null)
            {
                return HttpNotFound();
            }
            return View(adModel);
        }

        // POST: AdModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Active,Type,ImagePath,Area,ShortDescription,Skills,Links,AddingDate")] AdModel adModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adModel);
        }

        // GET: AdModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModel adModel = db.Ads.Find(id);
            if (adModel == null)
            {
                return HttpNotFound();
            }
            return View(adModel);
        }

        // POST: AdModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdModel adModel = db.Ads.Find(id);
            db.Ads.Remove(adModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
