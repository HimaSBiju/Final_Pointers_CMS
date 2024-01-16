using System;

namespace Pointers_CMS.ViewModel.ReceptionistVM
{
    public class AppointmentViewModel
    {

            public int AppointmentId { get; set; }
            public int TokenNo { get; set; }
            public DateTime AppointmentDate { get; set; }
            public int PatientId { get; set; }
            public int DocId { get; set; }

            public string CheckUpStatus { get; set; }
            public int BillId { get; set; }
            public decimal? RegisterFees { get; set; }

            public decimal? TotalAmount { get; set; }
            public decimal? ConsultationFee { get; set; }

        }
    }
