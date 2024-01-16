using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.AdminVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.A_Repository
{
    public interface A_IStaffRepository
    {
        Task<List<A_StaffVM>> GetStaffDetails();
        Task<A_StaffVM> GetStaffDetailsById(int? staffId);
        Task<int> AddStaffWithRelatedData(A_StaffVM staffDetails);
        Task UpdateStaff(Staffs staff);
    }
}
