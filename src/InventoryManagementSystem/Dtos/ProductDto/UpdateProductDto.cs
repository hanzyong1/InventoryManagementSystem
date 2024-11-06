namespace InventoryManagementSystem.Dtos.ProductDto
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public double? Price { get; set; }
    }
}
