
using BL.DTOs;
using DL.Entities;
using DL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstractions.Interfaces
{
    public interface ICategoryRepo
    {
        //GetCategoryDTO Add(int userId, AddCategoryDTO dto);
        //GetCategoryDTO Update(UpdateCategoryDTO dto);
        List<GetCategoryDTO> Get();
        PagedResult<Category> Get(int offset, int limit, string query);
        GetCategoryDTO Get(int id);
        GetCategoryDTO Insert(GetCategoryDTO dto);
        GetCategoryDTO Update(int id, GetCategoryDTO dto);
        GetCategoryDTO Delete(int id);
        //PagedResult<Category> Get(int userId, int offset, int limit, bool all, string query);
        //void Delete(int categoryId);
        //Task Delete();
    }
}
