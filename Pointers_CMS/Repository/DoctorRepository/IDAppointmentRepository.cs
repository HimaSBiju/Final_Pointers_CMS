using Pointers_CMS.ViewModel.DoctorVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.DoctorRepository
{
    public interface IDAppointmentRepository
    {
        Task<List<AppointmentsVM>> GetAppointmentViewAsync(int docId);
    }
}