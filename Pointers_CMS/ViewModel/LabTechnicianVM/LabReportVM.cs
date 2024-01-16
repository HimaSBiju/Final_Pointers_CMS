using System;

namespace Pointers_CMS.ViewModel.LabTechnicianVM
{
    public class LabReportVM
    {
        public string PatientName { get; set; }

        public string TestName { get; set; }

        public string LowRange { get; set; }

        public string HighRange { get; set; }

        public string TestResult { get; set; }

        public string Remarks { get; set; }
        public int ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
    }
}
