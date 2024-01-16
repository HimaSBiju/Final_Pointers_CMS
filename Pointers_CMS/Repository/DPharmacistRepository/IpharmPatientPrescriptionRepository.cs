using Pointers_CMS.ViewModel.PharPatientPrescriptionViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.DPharmacistRepository
{
    public interface IpharmPatientPrescriptionRepository
    {
        Task<List<PharmacistViewModel>> GetAllPatientPrescriptions();

        Task<List<PharmacistViewModel>> SearchPatientPrescriptionsByPatientId(int? patientId);
    }
}
