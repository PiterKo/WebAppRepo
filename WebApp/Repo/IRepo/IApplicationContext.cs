using Repo.Models;
using Repo.Models.Partial;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repo.IRepo
{
    public interface IApplicationContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<AdModel> Ads { get; set; }
        DbSet<AdType> AdType { get; set; }
        DbSet<AdCategory> AdCategories { get; set; }

        int SaveChanges();
        Database Database { get; }
    }
}