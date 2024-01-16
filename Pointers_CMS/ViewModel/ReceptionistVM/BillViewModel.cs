using System;

namespace Pointers_CMS.ViewModel.ReceptionistVM
{
        public class BillViewModel
        {
            public int AppointmentId { get; set; }
            public int TokenNo { get; set; }
            public DateTime AppointmentDate { get; set; }
            public int? PatientId { get; set; }
            public int? DocId { get; set; }
            public string CheckupStatus { get;  set; }

            public int BillId { get; set; }

            public decimal? RegistrationFee { get; set; }
            public decimal TotalAmt { get; set; }
            public int? StaffId { get; set; }
            public int? SpecializationId { get; set; }
            public decimal? ConsultationFee { get; set; }
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }

            public string PatientName { get; set; }
        public string RegisterNo { get; set; }
        public string FullName { get; set; }



    }
    }


