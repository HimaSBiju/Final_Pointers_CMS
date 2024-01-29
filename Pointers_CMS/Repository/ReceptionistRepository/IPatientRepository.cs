using Pointers_CMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.ReceptionistRepository
{
    public interface IPatientRepository
    {
        Task<List<Patients>> GetAllPatient();

        Task<int> AddPatient(Patients pa);
        Task<Patients> UpdatePatient(Patients pa);
        Task<Patients> GetPatientByPhoneNumberAndName(long phoneNumber, string name);
        Task<Patients> DisableStatus(int? paitientId);

        Task<List<Patients>> GetAllDisabledPatients();
        Task<Patients> EnableStatus(int? paitientId);
        Task<Patients> GetPatientById(int? id);





    }
}
