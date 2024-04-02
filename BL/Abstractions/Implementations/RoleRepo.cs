    using BL.Abstractions.Interfaces;
    using BL.DTOs;
    using BL.Services;
    using DL;
using DL.Commons;
using DL.Entities;
    using DL.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Omu.ValueInjecter;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace BL.Abstractions.Implementations
    {
        public class RoleRepo : IRoleRepo
        {
            private readonly IGenericRepository<Role> _genericRepo;
            private ICacheService _cacheService;
            private ApplicationDBContext _context;

            public RoleRepo(ApplicationDBContext context, ICacheService cacheService,IGenericRepository<Role> genericRepo)
            {
                _context = context;
                _cacheService = cacheService;
                _genericRepo= genericRepo;
            }

            public GetRoleDTO Insert(GetRoleDTO dto)
            {
                var role = new Role()
                {
                    Name = dto.Name,
                };
                var roleId = _genericRepo.Insert(role);

                var permissions = _context.Permissions.Select(_ => _.Id).ToList();

                var rolePermission = new List<RolePermission>();
                permissions.ForEach(id => rolePermission.Add(new RolePermission
                {
                    RoleId = roleId,
                    PermissionId = id,
                    IsAllowed = false
                }));

                _context.RolePermission.AddRange(rolePermission);
                _context.SaveChanges();

                return Mapper.Map<GetRoleDTO>(role);
            }
        public GetRoleDTO Update(int id, GetRoleDTO dto)
        {
                var roleEntity = _genericRepo.Get(id);

                // Update the role entity's name
                roleEntity.Name = dto.Name;

            
                foreach (var permissionDto in dto.RolePermission)
                {
                    var existingRolePermission = roleEntity.RolePermissions.FirstOrDefault(rp => rp.PermissionId == permissionDto.PermissionId);
                    if (existingRolePermission != null)
                    {
                        existingRolePermission.IsAllowed = permissionDto.IsAllowed;
                    }
                }

          
                _genericRepo.Update(roleEntity);

                return Mapper.Map<GetRoleDTO>(roleEntity);
            }

            public List<RolePermissions> RoleDetails(int id)
            {
                var role = (from r in _context.Roles
                           join rp in _context.RolePermission
                           on r.Id equals rp.RoleId
                           join p in _context.Permissions
                           on rp.PermissionId equals p.Id
                           select new RolePermissions
                           {
                               Role = r.Name,
                               Permission = p.Name,
                               IsAllowed = rp.IsAllowed
                           }).ToList();
                return role;
            }

        public List<GetRoleDTO> Get()
        {
            List<GetRoleDTO> roles = new List<GetRoleDTO>();
            var cachedData = _cacheService.Get<IEnumerable<GetCategoryDTO>>(CacheKeys.ROLE);
            if (cachedData == null || cachedData.Count() == 0)
            {
                var data = _genericRepo.GetAll().ToList();

                foreach (var category in data)
                {
                    roles.Add(Mapper.Map<GetRoleDTO>(category));
                }
                _cacheService.Set(CacheKeys.ROLE, roles);
            }
            else
            {
                roles = (List<GetRoleDTO>)cachedData;
            }

            return roles;
        }
        public GetRoleDTO Delete(int id)
        {
            var deletedrole = _genericRepo.Get(id);
            deletedrole.IsDeleted = false;
            var categoryId = _genericRepo.Delete(deletedrole);
            return Mapper.Map<GetRoleDTO>(deletedrole);
        }
    }
    }
