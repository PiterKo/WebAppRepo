using Repo.Models;
using Repo.Models.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.IRepo
{
    public interface IAd
    {
        bool CreateAd(AdModel adModel, HttpPostedFileBase imagePath, string userId, string path);

        void PostAd(AdModel adModel);
    }
}