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
    internal class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> builder)
        {
            builder.HasData(
                new DoctorPatient
                {
                    DoctorId = 1,
                    PatientId = 1
                },
                new DoctorPatient
                {
                    DoctorId = 1,
                    PatientId = 2
                },
                new DoctorPatient
                {
                    DoctorId = 2,
                    PatientId = 1
                },
                new DoctorPatient
                {
                    DoctorId = 2,
                    PatientId = 2
                });
        }
    }
}
