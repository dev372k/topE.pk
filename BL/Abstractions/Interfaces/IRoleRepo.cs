using BL.DTOs;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstractions.Interfaces
{
    public interface IRoleRepo
    {
        List<RolePermissions> RoleDetails(int id);
        List<GetRoleDTO> Get();
        GetRoleDTO Insert(GetRoleDTO dto);
        GetRoleDTO Update(int id, GetRoleDTO dto);
        GetRoleDTO Delete(int id);
    }
}
