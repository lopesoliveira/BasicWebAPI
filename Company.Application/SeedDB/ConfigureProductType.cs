using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Company.Application.SeedDB {
    public class ConfigureProductType : IEntityTypeConfiguration<ProductType> {
        public void Configure(EntityTypeBuilder<ProductType> entity) {
            entity.HasData(
                new ProductType { Id=1, Name="Consolas de Jogos", Description="Consolas de Jogos"},
                new ProductType { Id=2, Name="Projector", Description="Para projectar video"}               
                );
        }
    }
}
