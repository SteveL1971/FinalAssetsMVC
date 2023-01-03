using FinalAssetsMVC1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalAssetsMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FinalAssetsMVC1.Models.Item> Item { get; set; }

        public DbSet<FinalAssetsMVC1.Models.Asset> Asset { get; set; }

        public DbSet<FinalAssetsMVC1.Models.Office> Office { get; set; }

        public DbSet<FinalAssetsMVC1.Models.Laptop> Laptop { get; set; }

        public DbSet<FinalAssetsMVC1.Models.Mobile> Mobile { get; set; }

        //public DbSet<Asset> Asset { get; set; }
        //public DbSet<Office> Office { get; set; }
        //public DbSet<Laptop> Laptop { get; set; }
        //public DbSet<Mobile> Mobile { get; set; }

    }
}