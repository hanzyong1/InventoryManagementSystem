using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
    }
}
