using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class PatientHistory
    {
        public int PatientHistoryId { get; set; }
        public int? LabReportId { get; set; }
        public int? DiagnosisId { get; set; }
        public int? MedPrescriptionId { get; set; }
        public int? LabPrescriptionId { get; set; }

        public virtual Diagnosis Diagnosis { get; set; }
        public virtual LabPrescriptions LabPrescription { get; set; }
        public virtual LabReportGeneration LabReport { get; set; }
        public virtual MedicinePrescriptions MedPrescription { get; set; }
    }
}
