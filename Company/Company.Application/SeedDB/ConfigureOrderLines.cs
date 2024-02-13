using Company.Company.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Company.Company.Application.SeedDB {
    public class ConfigureOrderLines : IEntityTypeConfiguration<OrderLines> { //TO-DO - O preço deve vir do producto * quantidade
        public void Configure(EntityTypeBuilder<OrderLines> entity) {
            entity.Property(i => i.Price).HasPrecision(20 , 2);
            entity.HasData(
                new OrderLines { Id=1, OrderId = 1 , ProductId = 1 , Quantity = 1 , Price = 250 } ,
                new OrderLines { Id=2, OrderId = 1 , ProductId = 2 , Quantity = 1 , Price = 250 }
                );
        }
    }
}
