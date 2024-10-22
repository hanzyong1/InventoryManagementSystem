using InventoryManagementSystem.Data.Repositories;
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

            return await MapToEntityDto(product);
        }

        public async Task<List<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var categoryList = await _categoryRepository.GetAll();

            var productDtos = new List<GetProductDto>();

            foreach (var product in products)
            {
                var result = await MapToEntityDto(product);
                productDtos.Add(result);
            }

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

            return await MapToEntityDto(result);
        }

        public async Task<GetProductDto?> Update(UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.Get(updateProductDto.Id);

            if (product == null)
            {
                return null;
            }

            product.Name = updateProductDto.Name;
            product.Description = !string.IsNullOrEmpty(updateProductDto.Description) ? updateProductDto.Description : null;
            product.CategoryId = updateProductDto.CategoryId;
            product.Price = updateProductDto?.Price ?? 0.0;
            product.Quantity = updateProductDto?.Quantity ?? 0;

            await _unitOfWork.CommitAsync();
            return await MapToEntityDto(product);
        }

        public async Task Delete(int id)
        {
            var product = await _productRepository.Get(id);

            if (product == null)
            {
                return;
            }

            _productRepository.Delete(product);
            await _unitOfWork.CommitAsync();
        }

        private async Task<GetProductDto> MapToEntityDto(Product product)
        {
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
    }
}
