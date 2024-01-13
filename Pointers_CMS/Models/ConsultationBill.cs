using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class ConsultationBill
    {
        public int BillId { get; set; }
        public decimal? RegistrationFee { get; set; }
        public decimal TotalAmt { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
    }
}
