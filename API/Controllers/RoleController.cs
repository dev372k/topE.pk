using API.Models;
using BL.Abstractions.Implementations;
using BL.Abstractions.Interfaces;
using BL.DTOs;
using BL.Services;
using DL;
using DL.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private IRoleRepo _roleRepo;
        private ICacheService _cacheService;
        private ApplicationDBContext _context;

        public RoleController(IRoleRepo roleRepo, ApplicationDBContext context, ICacheService cacheService)
        {
            _roleRepo = roleRepo;
        }

        [HttpGet("{id}"), Authorize]
        [HasPermission(PermissionConstants.ROLE)]
        public IActionResult RoleDetails(int id)
        {
            return Ok(new ResponseModel { Data = _roleRepo.RoleDetails(id) });
        }
        [HttpGet("all"), Authorize]
        [HasPermission(PermissionConstants.ROLE)]
        public IActionResult Get() =>
        Ok(new ResponseModel { Data = _roleRepo.Get() });

        [HttpPost, Authorize]
        [HasPermission(PermissionConstants.ROLE)]
        public IActionResult Post([FromBody] GetRoleDTO dto)
        {
            var result = _roleRepo.Insert(dto);
            return Ok(new ResponseModel { Data = result, Message = ResponseMessages.ROLE_ADDED });
        }

        [HttpPut,Authorize]
        [HasPermission(PermissionConstants.ROLE)]
        public IActionResult Update(int id, GetRoleDTO dto)
        {
            var updatedRole = _roleRepo.Update(id, dto);
            return Ok(new ResponseModel { Data = updatedRole, Message = ResponseMessages.ROLE_UPDATED });
        }
        [HttpDelete, Authorize]
        [HasPermission(PermissionConstants.ROLE)]
        public IActionResult Delete(int id) =>
            Ok(new ResponseModel { Data = _roleRepo.Delete(id),, Message = ResponseMessages.ROLE_DELETED });
    }
}
