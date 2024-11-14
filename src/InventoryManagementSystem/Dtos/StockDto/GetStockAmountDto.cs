using InventoryManagementSystem.Dtos.ProductDto;

namespace InventoryManagementSystem.Dtos.StockDto
{
    public class GetStockAmountDto
    {
        public GetProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
