﻿using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Data.UnitOfWork;
using InventoryManagementSystem.Dtos.CategoryDto;
using InventoryManagementSystem.Dtos.ProductDto;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
            )
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetProductDto?> Get(int id)
        {
            var product = await _productRepository.Get(id);

            if (product == null)
            {
                return null;
            }

            var category = await _categoryRepository.Get(product.CategoryId);

            return new GetProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = new GetCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                },
                Quantity = product.Quantity,
                Price = product.Price,
            };
        }

        public async Task<List<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var categoryList = await _categoryRepository.GetAll();

            var productDtos = products.Select(product =>
            {
                var category = categoryList.FirstOrDefault(e => e.Id == product.CategoryId);

                return new GetProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = new GetCategoryDto
                    {
                        Id = category.Id,
                        Name = category.Name,
                    },
                    Quantity = product.Quantity,
                    Price = product.Price,
                };
            }).ToList();

            return productDtos;
        }

        public async Task<GetProductDto> Create(CreateProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Description = !string.IsNullOrEmpty(productDto.Description) ? productDto.Description : null,
                CategoryId = productDto.CategoryId,
                Quantity = productDto.Quantity ?? 0,
                Price = productDto.Price ?? 0.0,
            };

            var result = await _productRepository.Create(product);
            await _unitOfWork.CommitAsync();

            return await Get(result.Id);
        }
    }
}
