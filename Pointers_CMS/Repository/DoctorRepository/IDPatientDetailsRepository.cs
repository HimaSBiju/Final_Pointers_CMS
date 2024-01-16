using Pointers_CMS.ViewModel.DoctorVM;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.DoctorRepository
{
    public interface IDPatientDetailsRepository
    {
        Task<PatientDetailsVM> GetPatientViewAsync(int appointmentId);
    }
}