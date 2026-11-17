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

        public async Task<List<Doctor>> GetAllDoctorsAsync(string? search, string? specialty, string? sortOrder)
        {
            var query= context_new.Doctors.Include(d=>d.Hospital).Where(x=>true);
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search));
            }
            if (!string.IsNullOrEmpty(specialty))
            {
                query = query.Where(x => x.Specialty.Contains(specialty));
            }
            switch(sortOrder)
            {
                case "name_asc":
                    query = query.OrderBy(x => x.FirstName).ThenBy(x=>x.LastName);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(x => x.FirstName).ThenByDescending(x=>x.LastName);
                    break;
                case "specialty":
                    query = query.OrderBy(x => x.Specialty).ThenBy(x=>x.FirstName);
                    break;
                default:
                    query = query.OrderBy(x => x.FirstName).ThenBy(x=>x.LastName);
                    break;
            }
            return await query.ToListAsync();
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
             return await context_new.Doctors.Include(d => d.Hospital)
                .Include(x => x.DoctorPatients)
                .ThenInclude(x => x.Patient)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
