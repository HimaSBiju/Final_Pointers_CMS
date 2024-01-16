using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.DoctorVM;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pointers_CMS.Repository.DoctorRepository
{
    public class DPatientHistoryRepository : IDPatientHistoryRepository
    {
        private readonly DB_CMSContext _DbContext;
        public DPatientHistoryRepository(DB_CMSContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<List<PatientHistoryVM>> GetPatientHistoryAsync(int patientId)
        {

            if (_DbContext != null)
            {
                var patientHistory = await _DbContext.Appointments
             .Include(a => a.Diagnosis)
                 .ThenInclude(d => d.PatientHistory)
             .Include(a => a.LabPrescriptions)
                 .ThenInclude(lp => lp.LabTest)
             .Include(a => a.MedicinePrescriptions)
                 .ThenInclude(mp => mp.PrescribedMedicine)
             .Include(a => a.LabReportGeneration)
                 .ThenInclude(rg => rg.Test)
             .Where(a => a.PatientId == patientId)
             .Select(a => new PatientHistoryVM
             {
                 AppointmentDate = a.AppointmentDate,
                 Symptoms = a.Diagnosis.Symptoms,
                 Diagnosis = a.Diagnosis.Diagnosis1,
                 Note = a.Diagnosis.Note,
                 MedicineName = a.MedicinePrescriptions.FirstOrDefault().PrescribedMedicine.MedicineName,
                 LabTestName = a.LabPrescriptions.FirstOrDefault().LabTest.TestName,
                 LabResult = a.LabReportGeneration.FirstOrDefault().TestResult ?? "N.A"
             })
             .ToListAsync();

                return patientHistory;



            }
            return null;

        }
    }
}
