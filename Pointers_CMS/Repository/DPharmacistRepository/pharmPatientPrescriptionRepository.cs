using Pointers_CMS.Models;
using Pointers_CMS.ViewModel.PharPatientPrescriptionViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pointers_CMS.Repository.DPharmacistRepository
{
    public class pharmPatientPrescriptionRepository:IpharmPatientPrescriptionRepository
    {

        private readonly DB_CMSContext _context;
        private object _Context;

        public pharmPatientPrescriptionRepository(DB_CMSContext context)
        {
            _context = context;
        }

        public async Task<List<PharmacistViewModel>> GetAllPatientPrescriptions()
        {
            if (_context != null)
            {
                var patientPrescriptions = await (
                    from appointment in _context.Appointments
                    join patient in _context.Patients on appointment.PatientId equals patient.PatientId
                    join prescription in _context.MedicinePrescriptions on appointment.AppointmentId equals prescription.AppointmentId
                    select new PharmacistViewModel

                    {
                        PatientId = patient.PatientId,
                        PatientName = patient.PatientName,
                        PhoneNumber = patient.PhNo,
                        PrescribedMedicine = prescription.PrescribedMedicine.MedicineName,
                        Dosage = prescription.Dosage,
                        DosageDays = prescription.DosageDays,
                        Quantity = prescription.MedicineQuantity
                    }).ToListAsync();

                return patientPrescriptions;
            }

            return null;
        }
        public async Task<List<PharmacistViewModel>> SearchPatientPrescriptionsByPatientId(int? patientId)
        {
            if (_context != null && patientId.HasValue)
            {
                var patientPrescriptions = await (
                    from appointment in _context.Appointments
                    join patient in _context.Patients on appointment.PatientId equals patient.PatientId
                    join prescription in _context.MedicinePrescriptions on appointment.AppointmentId equals prescription.AppointmentId
                    where patient.PatientId == patientId
                    select new PharmacistViewModel
                    {
                        PatientId = patient.PatientId,
                        PatientName = patient.PatientName,
                        PhoneNumber = patient.PhNo,
                        PrescribedMedicine = prescription.PrescribedMedicine.MedicineName,
                        Dosage = prescription.Dosage,
                        DosageDays = prescription.DosageDays,
                        Quantity = prescription.MedicineQuantity
                    }).ToListAsync();

                return patientPrescriptions;
            }

            return null;
        }
    }
}
