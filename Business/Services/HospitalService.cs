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
    public class HospitalService :IHospitalService
    {
        private readonly HospitalDbContext context_new;
        public HospitalService(HospitalDbContext context)
        {
            context_new=context;
        }

        public async Task AddHospitalAsync(Hospital hospital)
        {
            context_new.Hospitals.Add(hospital);
            await context_new.SaveChangesAsync();
        }

        public async Task DeleteHospitalAsync(int id)
        {
            var hospital=await context_new.Hospitals.FindAsync(id);
            if (hospital != null)
            {
                hospital.IsDeleted = true;
            await context_new.SaveChangesAsync();
            }
        }

        public async Task<List<Hospital>> GetAllHospitalsAsync()
        {
           return await context_new.Hospitals.Where(x=>!x.IsDeleted).ToListAsync();
        }

        public async Task<Hospital?> GetHospitalAsync(int id)
        {
            return await context_new.Hospitals.FindAsync(id);
        }

        public async Task UpdateHospitalAsync(Hospital hospital)
        {
            await context_new.SaveChangesAsync();
        }
    }
}
