using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data_Hospital_Manager.Configurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasData(
                new Hospital
                {
                    Id = 1,
                    Name = "Болница Шипченска",
                    Address = "бул. Шипченски проход 15, София",
                    Email = "info@shipchenska.bg",
                    PhoneNumber = "+35929876543",
                    BedsCount = 500,
                    CreatedOn = new DateTime(2020, 1, 15),
                    IsDeleted = false
                },
                new Hospital
                {
                    Id = 2,
                    Name = "Св. Ана",
                    Address = "ул. Иван Вазов 8, Пловдив",
                    Email = "contact@svana.bg",
                    PhoneNumber = "+35932987654",
                    BedsCount = 320,
                    CreatedOn = new DateTime(2018, 5, 10),
                    IsDeleted = false
                }
            );
        }
    }
}
