using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager
{
    public class HospitalDbContext:DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
        }
        public DbSet <Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Начални данни за болниците
            modelBuilder.Entity<Hospital>().HasData(
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

            // Начални данни за лекарите (HospitalId сочи към вечеseed-аните болници)
            modelBuilder.Entity<Doctor>().HasData(
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

            // Начални данни за пациентите
            modelBuilder.Entity<Patient>().HasData(
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

            // Начални данни в свързващата таблица DoctorPatient (лекар-пациент)
            modelBuilder.Entity<DoctorPatient>().HasData(
                new DoctorPatient { DoctorId = 1, PatientId = 1 },
                new DoctorPatient { DoctorId = 1, PatientId = 2 },
                new DoctorPatient { DoctorId = 2, PatientId = 3 }
            );

            modelBuilder.Entity<DoctorPatient>().HasKey(dp => new { dp.DoctorId, dp.PatientId });
            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Doctor)
                .WithMany(d => d.DoctorPatients)
                .HasForeignKey(dp => dp.DoctorId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DoctorPatient>().HasOne(dp => dp.Patient)
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(dp => dp.PatientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
