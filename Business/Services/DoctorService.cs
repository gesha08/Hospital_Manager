using Business.Interfaces;
using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalDbContext context_new;
        public DoctorService(HospitalDbContext context)
        {
            context_new = context;
        }
        public async Task AddDoctorAsync(Doctor doctor)
        {
            context_new.Doctors.Add(doctor);
            await context_new.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor= await context_new.Doctors.Include(x=>x.DoctorPatients).FirstOrDefaultAsync(x => x.Id == id);
            if (doctor != null)
            {
                context_new.DoctorPatients.RemoveRange(doctor.DoctorPatients);
                context_new.Doctors.Remove(doctor);
                await context_new.SaveChangesAsync();
            }
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await context_new.Doctors.Include(x=>x.DoctorPatients).ThenInclude(x=>x.Patient).ToListAsync();
        }

        public async Task<Doctor?> GetDoctorAsync(int id)
        {
            return await context_new.Doctors.FindAsync(id);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await context_new.SaveChangesAsync();
        }
        public async Task<Doctor> GetDoctorDetailsAsync(int id)
        {
             return await context_new.Doctors.Include(x => x.DoctorPatients)
                .ThenInclude(x => x.Patient)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
