using API.Models;
using BL.Abstractions.Implementations;
using BL.Abstractions.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using DL.Commons;
using Microsoft.AspNetCore.Authorization;
using BL.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet, Authorize]
        [HasPermission(PermissionConstants.CATEGORY)]
        public IActionResult Get(int offset = 1, int limit = 10, string query = "") =>
            Ok(new ResponseModel { Data = _categoryRepo.Get(offset, limit, query) });

        [HttpGet("all")]
        public IActionResult Get() =>
            Ok(new ResponseModel { Data = _categoryRepo.Get() });


        [HttpGet("{id}"), Authorize]
        [HasPermission(PermissionConstants.CATEGORY)]
        public IActionResult Get(int id) =>
            Ok(new ResponseModel { Data = _categoryRepo.Get(id) });

        [HttpPost]
        public IActionResult Post([FromBody] GetCategoryDTO dto) =>
            Ok(new ResponseModel { Data = _categoryRepo.Insert(dto), Message = ResponseMessages.CATEGORY_ADDED });

        [HttpPut]
        public IActionResult Put(int id, [FromBody] GetCategoryDTO dto)
        {
            var updatedcategory = _categoryRepo.Update(id,dto);
            return Ok(new ResponseModel { Data = updatedcategory });
        }

        [HttpDelete, Authorize]
        [HasPermission(PermissionConstants.CATEGORY)]
        public IActionResult Delete(int id) =>
            Ok(new ResponseModel { Data = _categoryRepo.Delete(id), Message = ResponseMessages.CATEGORY_DELETED });
    }
}
