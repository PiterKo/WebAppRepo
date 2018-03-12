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

namespace WebApp.Controllers
{
    public class AdsModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdModels
        public ActionResult Index()
        {
            var adModels = db.Ads.AsNoTracking();
            return View(adModels.ToList());
        }
    }
}
