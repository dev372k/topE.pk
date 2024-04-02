﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class Role : Base
    {
        public string Name { get; set; }
        public List<RolePermission> RolePermissions { get; set; }

    }
}
