using Microsoft.EntityFrameworkCore;
using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.LabTechnicianVM;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.LabRepository
{

    public class LabTestsRepository : ILabTestsRepository
    {
        private readonly DB_CMSContext _dbContext;

        public LabTestsRepository(DB_CMSContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<LabTestsVM>> GetLabTestPrescriptions()
        {
            if (_dbContext != null)
            {
                // LINQ
                // Assuming you have a DataContext named "dbContext"

                var detailsQuery = from lp in _dbContext.LabPrescriptions
                                   join a in _dbContext.Appointments on lp.AppointmentId equals a.AppointmentId
                                   join p in _dbContext.Patients on a.PatientId equals p.PatientId
                                   join d in _dbContext.Doctors on a.DocId equals d.DocId
                                   join s in _dbContext.Staffs on d.StaffId equals s.StaffId
                                   join l in _dbContext.LabTests on lp.LabTestId equals l.TestId
                                   where lp.LabTestStatus == "pending"

                                   select new LabTestsVM
                                   {
                                       AppointmentId = a.AppointmentId,
                                       PatientName = p.PatientName,
                                       TestName = l.TestName,
                                       DoctorName = s.FullName, // Changed from "staff_Name" to "fullName"
                                       LabTestStatus = lp.LabTestStatus,
                                       TestId=lp.LabTestId,
                                   };


                return await detailsQuery.ToListAsync();
            }

            return null;
        }

       
    }
}
