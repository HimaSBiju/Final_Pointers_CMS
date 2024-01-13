using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            PatientHistory = new HashSet<PatientHistory>();
        }

        public int DiagnosisId { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis1 { get; set; }
        public string Note { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
    }
}
