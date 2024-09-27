using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> Get(int id);
        Task<List<Category>> GetAll();
    }
}
