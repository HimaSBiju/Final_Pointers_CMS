using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class LoginDetails
    {
        public int? StaffId { get; set; }
        public string StaffName { get; set; }
        public string RoleName { get; set; }
        public DateTime? LoginTime { get; set; }
    }
}
