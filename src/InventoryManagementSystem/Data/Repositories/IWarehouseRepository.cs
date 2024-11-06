using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Repositories
{
    public interface IWarehouseRepository
    {
        Task<List<Warehouse>> GetAll();
    }
}
