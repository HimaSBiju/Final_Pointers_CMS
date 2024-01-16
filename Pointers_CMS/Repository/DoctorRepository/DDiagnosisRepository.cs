using Microsoft.EntityFrameworkCore;
using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.DoctorVM;
using System.Linq;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.DoctorRepository
{
    public class DDiagnosisRepository : IDDiagnosisRepository
    {
        private readonly DB_CMSContext _dBCMSContext;
        public DDiagnosisRepository(DB_CMSContext dBCMSContext)
        {
            _dBCMSContext = dBCMSContext;
        }

        public async Task<int?> FillDiagForm(DiagnosisVM diagnosisVM)
        {
            var diagnosis = new Diagnosis
            {
                Symptoms = diagnosisVM.Symptoms ?? "",
                Diagnosis1 = diagnosisVM.Diagnosis1 ?? "",
                Note = diagnosisVM.Note ?? "",
                AppointmentId = diagnosisVM.AppointmentId
            };

            _dBCMSContext.Diagnosis.Add(diagnosis);
            await _dBCMSContext.SaveChangesAsync();

            // Insert into tbl_Medicineprescription
            var medicinePrescription = new MedicinePrescriptions
            {
                PrescribedMedicineId = diagnosisVM.PrescribedMedicineId,
                Dosage = diagnosisVM.Dosage ?? "",
                DosageDays = diagnosisVM.DosageDays,
                MedicineQuantity = diagnosisVM.MedicineQuantity,
                AppointmentId = diagnosisVM.AppointmentId
            };

            _dBCMSContext.MedicinePrescriptions.Add(medicinePrescription);
            await _dBCMSContext.SaveChangesAsync();

            // Insert into tbl_LabPrescription
            var labPrescription = new LabPrescriptions
            {
                LabTestId = diagnosisVM.LabTestId,
                LabNote = diagnosisVM.LabNote ?? "",
                AppointmentId = diagnosisVM.AppointmentId,
                LabTestStatus = diagnosisVM.LabTestStatus
            };

            _dBCMSContext.LabPrescriptions.Add(labPrescription);
            await _dBCMSContext.SaveChangesAsync();

            return diagnosisVM.AppointmentId;
        }

    }
}
