using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Appointments
    {
        public Appointments()
        {
            ConsultationBill = new HashSet<ConsultationBill>();
            LabPrescriptions = new HashSet<LabPrescriptions>();
            LabReportGeneration = new HashSet<LabReportGeneration>();
            MedicinePrescriptions = new HashSet<MedicinePrescriptions>();
        }

        public int AppointmentId { get; set; }
        public int TokenNo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string CheckupStatus { get; set; }
        public int? PatientId { get; set; }
        public int? DocId { get; set; }

        public virtual Doctors Doc { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual ICollection<ConsultationBill> ConsultationBill { get; set; }
        public virtual ICollection<LabPrescriptions> LabPrescriptions { get; set; }
        public virtual ICollection<LabReportGeneration> LabReportGeneration { get; set; }
        public virtual ICollection<MedicinePrescriptions> MedicinePrescriptions { get; set; }
    }
}
