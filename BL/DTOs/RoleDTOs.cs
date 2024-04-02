using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class RolePermissions
    {
        public string Role { get; set; }
        public string Permission { get; set; }
        public bool IsAllowed { get; set; }
    }

    public class GetRoleDTO
    {
     
        public string Name { get; set; }
        public List<RolePermission> RolePermission { get; set; }
    }

}
