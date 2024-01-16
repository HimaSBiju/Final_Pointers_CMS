using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.ReceptionistVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.ReceptionistRepository
{
    public interface IRAppointmentRepository
    {
        Task<List<Departments>> GetAllDepartment();
        Task<List<Specializations>> GetAllSpecializationByDepartmentId(int? departmentId);
        Task<List<DoctorViewModel>> GetAllDoctorBySpecializationId(int? specializationId);
        Task<AppointmentViewModel> BookAppointment(AppointmentViewModel viewModel, bool isNewPatient);
        Task<BillViewModel> BillDetails(int? billId);
        Task<List<BillViewModel>> GetAllAppointmentsWithBillViewModel();
        Task<BillViewModel> GetAppointmentDetailsById(int? appointmentId);
        Task<Appointments> CancelAppointment(int? appointmentId);

    }
}
