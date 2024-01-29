using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.LabTechnicianVM;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Pointers_CMS.Repository.LabRepository
{

    public class LabReportsRepository: ILabReportsRepository

    {
        private readonly DB_CMSContext _dbContext;
        public LabReportsRepository(DB_CMSContext dbContext)
        {
            _dbContext = dbContext;
        }
    #region GET
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

    #endregion

    #region GET
    public async Task<GetIDVM> GetIDViewModel(int AppointmentId)
    {
      if (_dbContext != null)
      {
        var query = from lr in _dbContext.LabPrescriptions
                    join a in _dbContext.Appointments on lr.AppointmentId equals a.AppointmentId
                    join p in _dbContext.Doctors on a.DocId equals p.DocId
                    join s in _dbContext.Staffs on p.StaffId equals s.StaffId
                    where lr.AppointmentId == AppointmentId
                    select new GetIDVM
                    {
                      LabPrescriptionId = lr.LabPrescriptionId,
                      AppointmentId = lr.AppointmentId,
                      TestId = lr.LabTestId,
                      StaffId = s.StaffId,

                    };

        return await query.FirstOrDefaultAsync();
      }
      return null;
    }
    #endregion

    #region POST
    public async Task<int> AddReport(LabReportVM viewmodal)
    {
      if (_dbContext != null)
      {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
          try
          {
            // Creating a new LabReportGeneration object and adding it to the context
            LabReportGeneration report = new LabReportGeneration()
            {
              AppointmentId = viewmodal.AppointmentId,
              TestResult = viewmodal.TestResult,
              ReportDate = viewmodal.ReportDate,
              Remarks = viewmodal.Remarks,
              TestId = viewmodal.TestId,
              StaffId = viewmodal.StaffId
            };

            _dbContext.LabReportGeneration.Add(report);
            await _dbContext.SaveChangesAsync();

            // Assuming that LabReportGeneration has an AppointmentId field
            int newReportId = report.ReportId;

            // Create a LabBillGeneration entry
            LabBillGeneration labBill = new LabBillGeneration()
            {
              ReportId = newReportId,
              BillDate = DateTime.Now, // You may customize this as needed
              TotalAmount = CalculateTotalAmount(viewmodal.TestId) // Replace with your logic for calculating total amount
            };

            _dbContext.LabBillGeneration.Add(labBill);
            await _dbContext.SaveChangesAsync();

            await UpdateLabTestStatus(viewmodal.LabPrescriptionId);


            transaction.Commit();

            return newReportId;
          }
          catch (Exception)
          {
            transaction.Rollback();
            return 0;
          }
        }
      }
      return 0;
    }


    #endregion

    #region Bill Generation
    public async Task<LabBillVM> GetBillVM(int ReportId)
    {
      if (_dbContext != null)
      {
        var query = from lb in _dbContext.LabBillGeneration
                    join l in _dbContext.LabReportGeneration on lb.ReportId equals l.ReportId
                    join a in _dbContext.Appointments on l.AppointmentId equals a.AppointmentId
                    join p in _dbContext.Patients on a.PatientId equals p.PatientId
                    join t in _dbContext.LabTests on l.TestId equals t.TestId
                    where lb.ReportId == ReportId
                    select new LabBillVM
                    {
                      BillId = lb.BillId,
                      AppointmentId = l.AppointmentId, // Assuming LabReportGeneration has an AppointmentId
                      TestId = l.TestId,
                      TestName=t.TestName,
                      Price = t.Price,
                      TotalAmount = lb.TotalAmount + lb.TotalAmount * 0.18m,
                      PatientId = p.PatientId,
                      PatientName = p.PatientName,
                      ReportId = lb.ReportId,
                    };

        return await query.FirstOrDefaultAsync();
      }
      return null;
    }



    #endregion

    private decimal CalculateTotalAmount(int? testId)
    {
      if (testId.HasValue)
      {
        // Retrieve the test price based on the provided testId
        LabTests labTest = _dbContext.LabTests.FirstOrDefault(t => t.TestId == testId);

        if (labTest != null)
        {
          // Replace this logic with your actual pricing calculation
          decimal testPrice = labTest.Price;

          // Calculate total amount (including GST)
          decimal totalAmount = testPrice + (testPrice * 0.18m); // Assuming 18% GST

          return totalAmount;
        }
      }

      return 0.00m;
    }


    public async Task<bool> UpdateLabTestStatus(int labPrescriptionId)
    {
      try
      {
        if (_dbContext != null)
        {
          var labPrescription = await _dbContext.LabPrescriptions.FindAsync(labPrescriptionId);

          if (labPrescription != null)
          {
            labPrescription.LabTestStatus = "completed";
            await _dbContext.SaveChangesAsync();
            return true;
          }
        }
      }
      catch (Exception)
      {
        // Handle exception if needed
      }

      return false;
    }




  }
}
