using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
    }
}
