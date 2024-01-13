using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class LoginUsers
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int? RoleId1 { get; set; }
    }
}
