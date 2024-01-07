using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Company.Application.SeedDB {
    public class ConfigureCompanies : IEntityTypeConfiguration<Companies> {
        public void Configure(EntityTypeBuilder<Companies> entity) {
            entity.HasData(
                new Companies { Id=1, CompanyName="Ok Computer", CompanyAddress="Verdemilho", CompanyDescription="Minha empresa"},
                new Companies { Id=2, CompanyName="Ok Computer SGPS", CompanyAddress="Bahamas", CompanyDescription="A minha Offshore"}                
                );

        }
    }
}
