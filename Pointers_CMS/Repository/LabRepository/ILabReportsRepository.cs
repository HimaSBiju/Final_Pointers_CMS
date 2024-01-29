using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.LabTechnicianVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.LabRepository
{
    public interface ILabReportsRepository
    {
        Task<List<LabReportVM>> GetViewModelReport();
    Task<int> AddReport(LabReportVM viewmodal);
    Task<GetIDVM> GetIDViewModel(int AppointmentId);


     Task<LabBillVM> GetBillVM(int ReportId);
  }
}
