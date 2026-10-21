using Data_Hospital_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient?> GetPatientAsync(int id);
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient,List<int> doctorIds);
        Task DeletePatientAsync(int id);
        Task<Patient> GetPatientDetailsAsync(int id);
    }
}
