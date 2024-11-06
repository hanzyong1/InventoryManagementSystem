using InventoryManagementSystem.Dtos.CategoryDto;

namespace InventoryManagementSystem.Dtos.ProductDto
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public double? Price { get; set; }
    }
}
