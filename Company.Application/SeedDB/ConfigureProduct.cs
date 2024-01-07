using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Company.Application.SeedDB {
    public class ConfigureProduct : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> entity) {
            entity.Property(i => i.Price).HasPrecision(20 , 2);
            entity.HasData(
                new Product { Id=1, Name="Nintendo", Description="Consola", Price=250, ProductTypeId=1 },
                new Product { Id=2, Name = "Projector" , Description = "Projecta" , Price = 250 , ProductTypeId = 2 }
                );
        }
    }
}
