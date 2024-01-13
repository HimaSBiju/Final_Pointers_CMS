using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Staffs
    {
        public Staffs()
        {
            Doctors = new HashSet<Doctors>();
            LabReportGeneration = new HashSet<LabReportGeneration>();
        }

        public int StaffId { get; set; }
        public string FullName { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public long MobileNo { get; set; }
        public int? LoginId { get; set; }
        public int? QualificationId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SpecializationId { get; set; }
        public int? RoleId { get; set; }
        public string Email { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Qualifications Qualification { get; set; }
        public virtual Roles Role { get; set; }
        public virtual Specializations Specialization { get; set; }
        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<LabReportGeneration> LabReportGeneration { get; set; }
    }
}
