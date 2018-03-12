using Repo.IRepo;
using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.Repos
{
    public class AdRepos : IAdsRepos
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<AdModel> GetAds()
        {
            return db.Ads.AsNoTracking();
        }
    }
}