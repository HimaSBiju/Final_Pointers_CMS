using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Qualifications
    {
        public Qualifications()
        {
            Staffs = new HashSet<Staffs>();
        }

        public int QualificationId { get; set; }
        public string Qualification { get; set; }

        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
