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
        private readonly IApplicationContext _db;

        public AdRepos(IApplicationContext db)
        {
            _db = db;
        }

        public IQueryable<AdModel> GetAds()
        {
            return _db.Ads.AsNoTracking();
        }
    }
}