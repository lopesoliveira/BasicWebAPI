using Company.Company.Application.SeedDB;
using Company.Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Company.Application.Contexts {
    public class CompanyContext : DbContext, ICompanyContext {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) {
        }
        /*DbSet<Companies>? Companies { get; set; }
        DbSet<Customer>? Customers { get; set; }
        DbSet<Order>? Orders { get; set; }
        DbSet<OrderLines>? OrderLines { get; set; }
        DbSet<Product>? Products { get; set; }
        DbSet<ProductType>? ProductTypes { get; set; }*/       
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ConfigureCompanies());
            modelBuilder.ApplyConfiguration(new ConfigureCustomer());
            modelBuilder.ApplyConfiguration(new ConfigureOrder());
            modelBuilder.ApplyConfiguration(new ConfigureOrderLines());
            modelBuilder.ApplyConfiguration(new ConfigureProduct());
            modelBuilder.ApplyConfiguration(new ConfigureProductType());
        }
    }
}
