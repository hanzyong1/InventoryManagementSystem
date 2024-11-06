using InventoryManagementSystem.Dtos.CategoryDto;

namespace InventoryManagementSystem.Dtos.ProductDto
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public GetCategoryDto Category { get; set; }
        public double Price { get; set; }
    }
}
