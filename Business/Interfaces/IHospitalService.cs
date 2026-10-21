using Data_Hospital_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IHospitalService
    {
        Task<List<Hospital>> GetAllHospitalsAsync();
        Task<Hospital?> GetHospitalAsync(int id);
        Task AddHospitalAsync(Hospital hospital);
        Task UpdateHospitalAsync(Hospital hospital);
        Task DeleteHospitalAsync(int id);

    }
}
