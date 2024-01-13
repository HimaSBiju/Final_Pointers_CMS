using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Specializations
    {
        public Specializations()
        {
            Doctors = new HashSet<Doctors>();
            Staffs = new HashSet<Staffs>();
        }

        public int SpecializationId { get; set; }
        public string Specialization { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
