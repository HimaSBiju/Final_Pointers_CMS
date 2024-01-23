using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.LabTechnicianVM;
using Pointers_CMS.ViewModel.LabTechnicianVM;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pointers_CMS.Repository.LabRepository
{

    public class LabReportsRepository: ILabReportsRepository

    {
        private readonly DB_CMSContext _dbContext;
        public LabReportsRepository(DB_CMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LabReportVM>> GetViewModelReport()
        {
            if (_dbContext != null)
            {
                var query = from lr in _dbContext.LabReportGeneration
                            join l in _dbContext.LabTests on lr.TestId equals l.TestId
                            join a in _dbContext.Appointments on lr.AppointmentId equals a.AppointmentId
                            join p in _dbContext.Patients on a.PatientId equals p.PatientId

                            select new LabReportVM
                            {
                                ReportDate = lr.ReportDate,
                                ReportId = lr.ReportId,
                                PatientName = p.PatientName,
                                TestName = l.TestName,
                                HighRange = l.HighRange,
                                LowRange = l.LowRange,
                                TestResult = lr.TestResult,
                                Remarks = lr.Remarks
                            };

                return await query.ToListAsync();
            }
            return null;
        }
        #region 
        public async Task<int> AddReport(LabReportGeneration report)
        {
            if (_dbContext != null)
            {
                await _dbContext.LabReportGeneration.AddAsync(report);
                await _dbContext.SaveChangesAsync();
                return report.ReportId;
            }
            return 0;
        }
        #endregion

        #region GET
        public async Task<GetIDVM> GetIDViewModel()
        {
            if (_dbContext != null)
            {
                var query = from lr in _dbContext.LabPrescriptions
                            join a in _dbContext.Appointments on lr.AppointmentId equals a.AppointmentId
                            join p in _dbContext.Doctors on a.DocId equals p.DocId
                            join s in _dbContext.Staffs on p.StaffId equals s.StaffId
                            select new GetIDVM
                            {
                                AppointmentId = lr.AppointmentId,
                                TestId = lr.LabTestId,
                                StaffId = s.StaffId,

                            };

                return await query.FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion




    }
}
