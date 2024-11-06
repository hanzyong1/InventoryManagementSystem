using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Repositories
{
    public interface IStockRepository
    {
        Task<Stock?> Get(int id);
        Task<List<Stock>> GetAllByProductId(int productId);
        Task<List<Stock>> GetAll();
    }
}
