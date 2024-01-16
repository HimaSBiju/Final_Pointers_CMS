using System;

namespace Pointers_CMS.ViewModel.DoctorVM
{
    public class AppointmentsVM
    {
        public int AppointmentId { get; set; }
        public int TokenNo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string CheckupStatus { get; set; }
        public int? PatientId { get; set; }
        public int? DocId { get; set; }
        public string PatientName { get; set; }
        public DateTime PatientDob { get; set; }
        public string PatientGender { get; set; }
        public int? PatientAge { get; set; }

    }
}
