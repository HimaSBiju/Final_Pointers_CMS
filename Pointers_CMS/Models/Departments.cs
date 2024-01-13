using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Specializations = new HashSet<Specializations>();
            Staffs = new HashSet<Staffs>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Specializations> Specializations { get; set; }
        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
