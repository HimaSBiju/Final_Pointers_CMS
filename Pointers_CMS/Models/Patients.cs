using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int PatientId { get; set; }
        public string RegisterNo { get; set; }
        public string PatientName { get; set; }
        public DateTime PatientDob { get; set; }
        public string PatientAddrs { get; set; }
        public string PatientGender { get; set; }
        public string BloodGrp { get; set; }
        public long PhNo { get; set; }
        public string PatientEmail { get; set; }
        public string PatientStatus { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
