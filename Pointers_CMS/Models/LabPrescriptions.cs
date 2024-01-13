using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class LabPrescriptions
    {
        public LabPrescriptions()
        {
            PatientHistory = new HashSet<PatientHistory>();
        }

        public int LabPrescriptionId { get; set; }
        public int? LabTestId { get; set; }
        public string LabNote { get; set; }
        public string LabTestStatus { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual LabTests LabTest { get; set; }
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
    }
}
