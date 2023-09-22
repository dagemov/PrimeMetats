using GreenwichPrimesMeats.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenwichPrimesMeats.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CreditClients> Credits { get; set; }
        public DbSet<DailyNominal> DailyNominals { get; set; }
        public DbSet<Lis> Lis { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceUser> ServiceUser { get; set; } 
        public DbSet<WeekNominal> WeekNominals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CreditClients>().HasIndex("Id","UserId").IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c=>c.Name).IsUnique();
            modelBuilder.Entity<DailyNominal>().HasIndex(d=>d.Id).IsUnique();
            modelBuilder.Entity<Lis>().HasIndex(l=>l.Id).IsUnique();
            modelBuilder.Entity<Phone>().HasIndex("Phone1","UserId").IsUnique();
            modelBuilder.Entity<ProductCategory>().HasIndex("ProductId", "CategoryId").IsUnique();
            modelBuilder.Entity<ServiceUser>().HasIndex("UserId", "ServiceId").IsUnique();
            modelBuilder.Entity<Service>().HasIndex(s => s.Id).IsUnique();
            modelBuilder.Entity<Schedule>().HasIndex(s=>s.Id).IsUnique();
            modelBuilder.Entity<WeekNominal>().HasIndex("Id", "UserId").IsUnique();
        }
    }
}
