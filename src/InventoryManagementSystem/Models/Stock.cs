using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class Stock
    {
        public Stock()
        {
            
        }
        public Stock(int warehouseId, int productId, int quantity = 0)
        {
            WarehouseId = warehouseId;
            ProductId = productId;
        }

        public int Id { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
