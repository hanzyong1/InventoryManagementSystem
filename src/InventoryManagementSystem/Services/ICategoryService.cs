using InventoryManagementSystem.Dtos.CategoryDto;

namespace InventoryManagementSystem.Services
{
    public interface ICategoryService
    {
        Task<GetCategoryDto?> Get(int id);
        Task<List<GetCategoryDto>> GetAll();
        Task<GetCategoryDto> Create(CreateCategoryDto createCategoryDto);
        Task<GetCategoryDto?> Update(UpdateCategoryDto updateCategoryDto);
        Task Delete(int id);
    }
}
