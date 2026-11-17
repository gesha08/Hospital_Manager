using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Name = "MBAL Kazanlak",
                    Address = "Kazanlak",
                    Email = "hospital@example.com",
                    PhoneNumber = "123-456-7890",
                    BedsCount = 200,
                    CreatedOn = new DateTime(2026, 1, 1),
                    IsDeleted = false,
                },
                new Hospital
                {
                    Id = 2,
                    Name = "MBAL Stara Zagora",
                    Address = "Stara Zagora",
                    Email = "hospital2@example.com",
                    PhoneNumber = "987-654-3210",
                    BedsCount = 350,
                    CreatedOn = new DateTime(2026, 1, 1),
                    IsDeleted = false,
                });
        }
    }
    }
