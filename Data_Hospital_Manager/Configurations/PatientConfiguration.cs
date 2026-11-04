using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Hospital_Manager.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData(
                new Patient
                {
                    Id = 1,
                    FirstName = "Анна",
                    LastName = "Димова",
                    Email = "anna.dimova@mail.bg",
                    PhoneNumber = "+359889111222"
                },
                new Patient
                {
                    Id = 2,
                    FirstName = "Петър",
                    LastName = "Стоянов",
                    Email = "petar.stoyanov@mail.bg",
                    PhoneNumber = "+359889222333"
                },
                new Patient
                {
                    Id = 3,
                    FirstName = "Елена",
                    LastName = "Кевагиева",
                    Email = "elena.kevagi@mail.bg",
                    PhoneNumber = "+359889333444"
                }
            );
        }
    }
}
