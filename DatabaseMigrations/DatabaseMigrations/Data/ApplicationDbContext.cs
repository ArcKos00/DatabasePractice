using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using CodeFirst.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryEntity> Categoryes { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<OrderDetailEntity> Details { get; set; } = null!;
        public DbSet<OrderEntity> Orders { get; set; } = null!;
        public DbSet<PaymentEntity> Payments { get; set; } = null!;
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<ShipperEntity> Shippers { get; set; } = null!;
        public DbSet<SupplierEntity> Suppliers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigure());
            modelBuilder.ApplyConfiguration(new CustomerConfigure());
            modelBuilder.ApplyConfiguration(new OrderDetailConfigure());
            modelBuilder.ApplyConfiguration(new OrderConfigure());
            modelBuilder.ApplyConfiguration(new PaymentConfigure());
            modelBuilder.ApplyConfiguration(new ProductConfigure());
            modelBuilder.ApplyConfiguration(new ShipperConfigure());
            modelBuilder.ApplyConfiguration(new SupplierConfigure());
        }
    }
}
