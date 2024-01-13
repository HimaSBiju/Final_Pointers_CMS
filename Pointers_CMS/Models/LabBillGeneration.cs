using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class LabBillGeneration
    {
        public int BillId { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? ReportId { get; set; }

        public virtual LabReportGeneration Report { get; set; }
    }
}
