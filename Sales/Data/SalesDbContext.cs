using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sales.Models;

namespace Sales.Data
{
    public class SalesDbContext : IdentityDbContext
    {
        public SalesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public DbSet<Province> Province { get; set; }

        public DbSet<District> District { get; set; }

        public DbSet<LocalBody> LocalBody { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SerialNumber>().HasIndex("Serialno").IsUnique();
            modelBuilder.Entity<Product>().HasIndex("PName").IsUnique();
            modelBuilder.Entity<Order>().Property(u => u.CId).IsRequired();
           
        }


    }
}
