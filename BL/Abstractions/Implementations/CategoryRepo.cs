using BL.Abstractions.Interfaces;
using BL.DTOs;
using BL.Services;
using DL.Commons;
using DL.Entities;
using DL.Helpers;
using DL.Repositories;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstractions.Implementations
{
    public class CategoryRepo : ICategoryRepo
    {
        private IGenericRepository<Category> _genericRepo;
        private ICacheService _cacheService;

        public CategoryRepo(IGenericRepository<Category> genericRepo, ICacheService cacheService)
        {
            _genericRepo = genericRepo;
            _cacheService = cacheService;
        }

        public GetCategoryDTO Delete(int id)
        {
            var deletedCategory = _genericRepo.Get(id);
            deletedCategory.IsDeleted =false;
            var categoryId = _genericRepo.Delete(deletedCategory);
            return Mapper.Map<GetCategoryDTO>(deletedCategory);
        }

        public PagedResult<Category> Get(int offset, int limit, string query)
        {
            var data = _genericRepo.GetAll()
                .Where(_ => (!string.IsNullOrEmpty(query) ? _.Name.ToLower().Contains(query.ToLower()) : true))
                .ToPageResult(offset, limit);
            return data;
        }

        public List<GetCategoryDTO> Get()
        {
            List<GetCategoryDTO> categories = new List<GetCategoryDTO>();
            var cachedData = _cacheService.Get<IEnumerable<GetCategoryDTO>>(CacheKeys.CATEGORY);
            if (cachedData == null || cachedData.Count() == 0)
            {
                var data = _genericRepo.GetAll().ToList();

                foreach (var category in data)
                {
                    categories.Add(Mapper.Map<GetCategoryDTO>(category));
                }
                _cacheService.Set(CacheKeys.CATEGORY, categories);
            }
            else
            {
                categories = (List<GetCategoryDTO>)cachedData;
            }

            return categories;
        }

        public GetCategoryDTO Get(int id)
        {
            return Mapper.Map<GetCategoryDTO>(_genericRepo.Get(id));
        }

        public GetCategoryDTO Insert(GetCategoryDTO dto)
        {
            var categoryentity = new Category
            {
                Name = dto.Name
            };
            var categoryId = _genericRepo.Insert(categoryentity);
            return new GetCategoryDTO
            {

                Name = dto.Name
            };
        }

        public GetCategoryDTO Update(int id, GetCategoryDTO dto)
        {
            var categoryEntity = _genericRepo.Get(id);
            categoryEntity.Name = dto.Name;
            var categoryId = _genericRepo.Update(categoryEntity);
            return Mapper.Map<GetCategoryDTO>(categoryEntity);

        }
    }
}

