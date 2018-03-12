using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.Repos
{
    public class AdRepos
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<AdModel> GetAds()
        {
            return db.Ads.AsNoTracking();
        }
    }
}