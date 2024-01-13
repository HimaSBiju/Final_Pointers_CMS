using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int DocId { get; set; }
        public int? StaffId { get; set; }
        public int? SpecializationId { get; set; }
        public decimal? ConsultationFee { get; set; }

        public virtual Specializations Specialization { get; set; }
        public virtual Staffs Staff { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
