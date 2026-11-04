using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Hospital_Manager.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(
                new Doctor
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Петров",
                    Specialty = "Кардиолог",
                    Email = "ivan.petrov@hospital.bg",
                    PhoneNumber = "+359888123456",
                    HospitalId = 1
                },
                new Doctor
                {
                    Id = 2,
                    FirstName = "Мария",
                    LastName = "Иванова",
                    Specialty = "Педиатр",
                    Email = "maria.ivanova@hospital.bg",
                    PhoneNumber = "+359888234567",
                    HospitalId = 2
                },
                new Doctor
                {
                    Id = 3,
                    FirstName = "Георги",
                    LastName = "Симеонов",
                    Specialty = "Хирург",
                    Email = "georgi.simeonov@hospital.bg",
                    PhoneNumber = "+359888345678",
                    HospitalId = 1
                }
            );
        }
    }
}
