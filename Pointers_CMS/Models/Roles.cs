﻿using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Staffs = new HashSet<Staffs>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
