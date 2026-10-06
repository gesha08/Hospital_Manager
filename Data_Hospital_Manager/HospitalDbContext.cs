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
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DoctorPatient>()
                .HasKey(dp => new { dp.DoctorId, dp.PatientId });
            
            modelBuilder.Entity<DoctorPatient>().HasOne(dp=>dp.Doctor).WithMany(dp=>dp.DoctorPatients).HasForeignKey(dp=>dp.DoctorId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DoctorPatient>().HasOne(dp=>dp.Patient).WithMany(x=>x.DoctorPatients).HasForeignKey(x=>x.PatientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
