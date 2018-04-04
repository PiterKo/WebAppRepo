using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Repo.IRepo;
using Repo.Models;
using Repo.Models.Partial;

namespace WebApp.Controllers
{
    public class AdModelsController : Controller
    {
        private readonly IAd _ad;
        private readonly IGetForView _getForView;

        public AdModelsController(IAd ad, IGetForView getForView)
        {
            _ad = ad;
            _getForView = getForView;
        }

        // GET: AdModels/Index
        [Authorize]
        public ActionResult Index()
        {
            // Check if User has created Ad
            if (_getForView.CheckAdByUserId(User.Identity.GetUserId()))
            {
                return RedirectToAction("Index", "Home");
            }

            // Get values for dropdownlist and checkboxlist (Ad Type and Ad Categories)
            AdModel adModel = _getForView.AdViewModel();

            return View(adModel);
        }

        // POST: AdModels/Index
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Index([Bind(Include = "ImagePath,Area,ShortDescription,Skills,AdType,SelectedCategories")] AdModel adModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                // Post Ad and saving changes
                var result = _ad.CreateAd(adModel,
                                            image,
                                            User.Identity.GetUserId(),
                                            Server.MapPath("~/UsersImages"));

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(adModel);
        }
    }
}
