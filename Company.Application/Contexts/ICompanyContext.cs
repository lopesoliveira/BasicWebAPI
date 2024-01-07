using Microsoft.EntityFrameworkCore;
using Company.Domain.Entities;

namespace Company.Application.Contexts {
    public interface ICompanyContext {

        DbSet<Companies> Companies { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderLines> OrderLines { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductType>  ProductTypes { get; set; }

    }
}
