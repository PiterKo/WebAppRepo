using Repo.Models;
using Repo.Models.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.IRepo
{
    public interface IAdsRepos
    {
        List<AdModel> GetAds();
        AdModel GetTypes();
        AdModel GetAdByUser(string userId);
        AdModel AdModel(AdModel adModel, string userId);
        void CreateAd(AdModel adModel);
    }
}