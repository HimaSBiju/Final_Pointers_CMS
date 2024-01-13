using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class LabReportGeneration
    {
        public LabReportGeneration()
        {
            LabBillGeneration = new HashSet<LabBillGeneration>();
            PatientHistory = new HashSet<PatientHistory>();
        }

        public int ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public string TestResult { get; set; }
        public string Remarks { get; set; }
        public int? AppointmentId { get; set; }
        public int? TestId { get; set; }
        public int? StaffId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual Staffs Staff { get; set; }
        public virtual LabTests Test { get; set; }
        public virtual ICollection<LabBillGeneration> LabBillGeneration { get; set; }
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
    }
}
