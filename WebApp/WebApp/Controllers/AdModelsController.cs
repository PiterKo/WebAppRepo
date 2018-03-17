using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        private readonly IAdsRepos _repos;

        public AdModelsController(IAdsRepos repos)
        {
            _repos = repos;
        }

        // GET: AdModels/Create
        [Authorize]
        public ActionResult Index()
        {
            if (_repos.GetAdByUser(User.Identity.GetUserId()) != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var dropDown = _repos.GetTypes();

            return View(dropDown);
        }

        // POST: AdModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Index([Bind(Include = "ImagePath,Area,ShortDescription,Skills,AdTypes")] AdModel adModel)
        {
            adModel = _repos.AdModel(adModel, User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                _repos.CreateAd(adModel);
                return RedirectToAction("Index", "Home");
            }

            return View(adModel);
        }
    }
}
