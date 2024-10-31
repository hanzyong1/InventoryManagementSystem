using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> Get(int id);
        Task<List<Category>> GetAll();
        Task<Category> Create(Category category);
        Task Delete(Category category);
    }
}
