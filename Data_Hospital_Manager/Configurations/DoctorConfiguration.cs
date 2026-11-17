using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Hospital_Manager.Configurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(
               new Doctor
               {
                   Id = 1,
                   FirstName = "Dimitar",
                   LastName = "Dimitrov",
                   Email = "doctor@example.com",
                   PhoneNumber = "123-456-7890",
                   HospitalId = 1,
                   Specialty = "Neurology"
               },
               new Doctor
               {
                   Id = 2,
                   FirstName = "Ivan",
                   LastName = "Ivanov",
                   Email = "doctor2@example.com",
                   PhoneNumber = "987-654-3210",
                   HospitalId = 2,
                   Specialty = "Cardiology"
               });
        }
    }
}
