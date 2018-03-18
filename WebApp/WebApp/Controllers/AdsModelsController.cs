using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repo.IRepo;
using Repo.Models;
using Repo.Repos;

namespace WebApp.Controllers
{
    public class AdsModelsController : Controller
    {
        private readonly IAdsRepos _repos;

        public AdsModelsController(IAdsRepos repos)
        {
            _repos = repos;
        }

        // GET: Ads
        public ActionResult Index()
        {
            var adModels = _repos.GetAds();

            return View(adModels);
        }
    }
}
