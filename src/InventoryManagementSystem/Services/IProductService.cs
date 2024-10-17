using InventoryManagementSystem.Dtos.ProductDto;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public interface IProductService
    {
        Task<GetProductDto?> Get(int id);
        Task<List<GetProductDto>> GetAll();
        Task<GetProductDto> Create(CreateProductDto createProductDto);
    }
}
