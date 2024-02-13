using Company.Company.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Company.Company.Application.SeedDB {
    public class ConfigureOrder : IEntityTypeConfiguration<Order> { //TO-DO - O totalPrice deve ser calculado
        public void Configure(EntityTypeBuilder<Order> entity) {
            entity.Property(i => i.TotalPrice).HasPrecision(20 , 2);
            entity.HasData(
                new Order { Id=1, TotalPrice=500, BillingAddress="Verdemilho", CustomerId=1}
                );
        }

    }
}
