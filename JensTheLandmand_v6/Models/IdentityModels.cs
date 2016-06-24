using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JensTheLandmand_v6.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Topics> Topics { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        //public virtual ICollection<Products> Products { get; set; }
        //public virtual ICollection<Links> Links { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Topics> Topics { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<File> File { get; set; }

        public DbSet<Audit> AuditRecords { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<JensTheLandmand_v6.Models.ProductViewModel> ProductViewModels { get; set; }

        public System.Data.Entity.DbSet<JensTheLandmand_v6.Models.ChartViewModel> ChartViewModels { get; set; }

        public System.Data.Entity.DbSet<JensTheLandmand_v6.Models.ChartProductDetailsViewModel> ChartProductDetailsViewModels { get; set; }

        public System.Data.Entity.DbSet<JensTheLandmand_v6.Models.UnikVisitsViewModel> UnikVisitsViewModels { get; set; }
    }
}