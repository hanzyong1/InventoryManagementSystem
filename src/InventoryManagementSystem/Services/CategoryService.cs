﻿using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Data.UnitOfWork;
using InventoryManagementSystem.Dtos.CategoryDto;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository
            )
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoryDto> Get(int id)
        {
            var category = await _categoryRepository.Get(id);

            if (category == null)
            {
                return null;
            }

            return MapToEntityDto(category);
        }

        private GetCategoryDto MapToEntityDto(Category category)
        {
            return new GetCategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}
