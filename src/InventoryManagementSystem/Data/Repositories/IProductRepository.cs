using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> Get(int id);
        Task<List<Product>> GetAll();
        Task<Product> Create(Product product);
        void Delete(Product product);
    }
}
