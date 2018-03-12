using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.IRepo
{
    public interface IAdsRepos
    {
        IQueryable<AdModel> GetAds();
    }
}