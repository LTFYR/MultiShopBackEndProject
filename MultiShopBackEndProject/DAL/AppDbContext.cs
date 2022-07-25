using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.Models;
using System.Linq;

namespace MultiShopBackEndProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                )
            {
                item.SetColumnType("decimal(6,2)");
            }
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setting>().HasIndex(b => b.Key).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Size>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Color>().HasIndex(c => c.Name).IsUnique();
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Clothe> Clothes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClotheCategory> ClotheCategories { get; set; }
        public DbSet<ClotheDescription> ClotheDescriptions { get; set; }
        public DbSet<ClotheImage> ClotheImages { get; set; }
        public DbSet<ClotheInformation> ClotheInformation { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}
