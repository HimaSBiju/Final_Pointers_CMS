using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class MedicinePrescriptions
    {
        public MedicinePrescriptions()
        {
            PatientHistory = new HashSet<PatientHistory>();
        }

        public int MedPrescriptionId { get; set; }
        public long? PrescribedMedicineId { get; set; }
        public string Dosage { get; set; }
        public int? DosageDays { get; set; }
        public int? MedicineQuantity { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual Medicines PrescribedMedicine { get; set; }
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
    }
}
