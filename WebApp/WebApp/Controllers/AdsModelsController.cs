using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using Repo.Repos;

namespace WebApp.Controllers
{
    public class AdsModelsController : Controller
    {
        AdRepos ad = new AdRepos();

        // GET: AdModels
        public ActionResult Index()
        {
            var adModels = ad.GetAds();
            return View(adModels.ToList());
        }
    }
}
