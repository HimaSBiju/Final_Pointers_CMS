using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class LabTests
    {
        public LabTests()
        {
            LabPrescriptions = new HashSet<LabPrescriptions>();
            LabReportGeneration = new HashSet<LabReportGeneration>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public string LowRange { get; set; }
        public string HighRange { get; set; }
        public int Price { get; set; }

        public virtual ICollection<LabPrescriptions> LabPrescriptions { get; set; }
        public virtual ICollection<LabReportGeneration> LabReportGeneration { get; set; }
    }
}
