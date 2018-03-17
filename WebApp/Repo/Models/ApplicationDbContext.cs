using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Repo.IRepo;
using Repo.Models.Partial;

namespace Repo.Models
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AdModel> Ads { get; set; }
        public DbSet<AdType> AdTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Disable pluraizing convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Disable CascadeDelete
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Using FluentAPI to set relationship
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.AdModel) 
                .WithRequired(ad => ad.ApplicationUser);

            modelBuilder.Entity<AdModel>()
                .HasRequired<AdType>(s => s.AdTypes)
                .WithMany(g => g.AdModels);
        }
    }
}