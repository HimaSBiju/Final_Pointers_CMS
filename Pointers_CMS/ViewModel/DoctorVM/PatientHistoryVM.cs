using System;

namespace Pointers_CMS.ViewModel.DoctorVM
{
    public class PatientHistoryVM
    {
        public string AppointmentDate { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string MedicineName { get; set; }
        public string LabTestName { get; set; }
        public string LabResult { get; set; }
        public string Note { get; set; }
        public int AppointmentId { get; set; }
    }
}
