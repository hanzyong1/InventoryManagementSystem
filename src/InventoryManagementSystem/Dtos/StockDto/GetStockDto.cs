using InventoryManagementSystem.Dtos.ProductDto;
using InventoryManagementSystem.Dtos.WarehouseDto;

namespace InventoryManagementSystem.Dtos.StockDto
{
    public class GetStockDto
    {
        public int Id { get; set; }
        public GetWarehouseDto Warehouse { get; set; }
        public GetProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
