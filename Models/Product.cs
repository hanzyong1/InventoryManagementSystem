using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(string name, string? description = null, int categoryId, int quantity, double price)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
