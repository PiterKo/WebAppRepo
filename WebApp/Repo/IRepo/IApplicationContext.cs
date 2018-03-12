using Repo.Models;
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

        // int SaveChages();
       Database Database { get; }
    }
}