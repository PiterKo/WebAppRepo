using Repo.IRepo;
using Repo.Models;
using Repo.Models.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.Repos
{
    public class GetForView : IGetForView
    {
        private readonly IApplicationContext _db;

        public GetForView(IApplicationContext db)
        {
            _db = db;
        }

        public IEnumerable<AdType> Types()
        {
            IEnumerable<AdType> types = new List<AdType>(_db.AdType.AsNoTracking().ToList());

            return types;
        }

        public IEnumerable<AdCategory> Categories()
        {
            IEnumerable<AdCategory> categories = new List<AdCategory>(_db.AdCategories.AsNoTracking().ToList());

            return categories;
        }

        public List<AdModel> Ads()
        {
            // Returning list of Ads from database
            return _db.Ads.AsNoTracking().ToList();
        }

        public AdModel AdViewModel()
        {
            AdModel view = new AdModel
            {
                AdCategories = this.Categories().ToList(),
                Types = this.Types()
            };

            return view;
        }

        public AdModel AdByUserId(string userId)
        {
            // Searching Ad by UserId
            var ad = _db.Ads
                .Where(s => s.ApplicationUser.Id == userId)
                .FirstOrDefault<AdModel>();

            return ad;
        }

        public bool CheckAdByUserId(string userId)
        {
            var ad = this.AdByUserId(userId);

            if(ad == null)
            {
                return false;
            }
            return true;
        }
    }
}