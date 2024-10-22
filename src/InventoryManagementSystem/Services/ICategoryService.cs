using InventoryManagementSystem.Dtos.CategoryDto;

namespace InventoryManagementSystem.Services
{
    public interface ICategoryService
    {
        Task<GetCategoryDto> Get(int id);
    }
}
