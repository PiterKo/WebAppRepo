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
        private readonly IGetForView _getForView;

        public AdsModelsController(IGetForView getForView)
        {
            _getForView = getForView;
        }

        // GET: Ads
        public ActionResult Index()
        {
            var ads = _getForView.Ads();

            return View(ads);
        }
    }
}
