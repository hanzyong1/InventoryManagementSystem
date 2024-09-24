using InventoryManagementSystem.Dtos.ProductDto;

namespace InventoryManagementSystem.Services
{
    public interface IProductService
    {
        Task<List<GetProductDto>> GetAll();
    }
}
