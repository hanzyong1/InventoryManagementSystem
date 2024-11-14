using InventoryManagementSystem.Dtos.StockDto;

namespace InventoryManagementSystem.Services
{
    public interface IStockService
    {
        Task<List<GetStockDto>> GetAllStocksOfProduct(int productId);
        Task<GetStockAmountDto> GetStockAmountByProductId(int productId);
    }
}
