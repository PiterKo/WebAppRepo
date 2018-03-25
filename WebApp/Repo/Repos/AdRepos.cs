using Repo.IRepo;
using Repo.Models;
using Repo.Models.Partial;
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

        public List<AdModel> GetAds()
        {
            return _db.Ads.AsNoTracking().ToList();
        }

        public AdModel GetTypes()
        {
            AdModel adModel = new AdModel
            {
                Types = _db.AdType.AsNoTracking().ToList(),
                AdCategories = _db.AdCategories.AsNoTracking().ToList()
            };

            return adModel;
        }

        public AdModel GetAdByUser(string userId)
        {
            var ad = _db.Ads
                .Where(s => s.ApplicationUser.Id == userId)
                .FirstOrDefault<AdModel>();

            return ad;
        }

        public AdModel AdModel(AdModel adModel, string userId)
        {
            adModel.ApplicationUser = _db.ApplicationUsers.Find(userId);

            adModel.AdType = _db.AdType.Find(adModel.AdType.Id);

            foreach (var categoryId in adModel.SelectedCategories.ToList())
            {
                adModel.AdCategories.Add(_db.AdCategories.Find(categoryId));
            }
           
            return adModel;
        }

        public void CreateAd(AdModel adModel)
        {
            _db.Ads.Add(adModel);
            _db.SaveChanges();
        }
    }
}