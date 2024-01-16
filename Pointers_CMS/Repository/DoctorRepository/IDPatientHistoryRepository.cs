using Pointers_CMS.ViewModel.DoctorVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.DoctorRepository
{
    public interface IDPatientHistoryRepository
    {
        Task<List<PatientHistoryVM>> GetPatientHistoryAsync(int patientId);
    }
}