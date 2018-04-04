using Repo.IRepo;
using Repo.Models;
using Repo.Models.Partial;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Repo.Repos
{
    public class Ad : IAd
    {
        private readonly IApplicationContext _db;

        public Ad(IApplicationContext db)
        {
            _db = db;
        }

        public void PostAd(AdModel adModel)
        {
            // Post Ad to database
            _db.Ads.Add(adModel);

            // Saving Changes
            _db.SaveChanges();
        }

        public string PostImage(HttpPostedFileBase image, string userId, string path)
        {
            string type = image.FileName.Remove(0, image.FileName.LastIndexOf("."));

            string p = Path.Combine(path, Path.GetFileName($"{ userId }{ type }"));

            image.SaveAs(p);

            return $"/UsersImages/{ userId }{ type }";
        }

        public bool CreateAd(AdModel adModel, HttpPostedFileBase image, string userId, string path)
        {
            // Adding User to AdModel
            adModel.ApplicationUser = _db.ApplicationUsers.Find(userId);

            // Adding Ad Type to AdModel
            adModel.AdType = _db.AdType.Find(adModel.AdType.Id);

            // Adding Categories to AdModel
            foreach (var categoryId in adModel.SelectedCategories.ToList())
            {
                adModel.AdCategories.Add(_db.AdCategories.Find(categoryId));
            }

            adModel.Image = this.PostImage(image, userId, path);

            this.PostAd(adModel);

            return true;
        }
    }
}