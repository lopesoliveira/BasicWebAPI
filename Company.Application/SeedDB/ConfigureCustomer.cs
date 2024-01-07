using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Company.Application.SeedDB {
    public class ConfigureCustomer : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> entity) {
            entity.HasData(
               new Customer { Id=1, Name="Olguinha", Address="Endereço", City="Minsk", Country="Bielorússia", Phone="123456789"},
               new Customer { Id=2, Name = "Tim" , Address = "Aradas" , City = "Aveiro" , Country = "Portugal" , Phone = "987654321" }
                );

        }
    }
}
