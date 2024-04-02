using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class RolePermission : Base
    {
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        [ForeignKey("PermissionId")]
        public int PermissionId { get; set; }

        public bool IsAllowed { get; set; } = true;
    }
}
