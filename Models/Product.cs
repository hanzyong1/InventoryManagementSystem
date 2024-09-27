using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(string name, int categoryId, int quantity, double price, string? description = null)
        {
            Name = name;
            CategoryId = categoryId;
            Quantity = quantity;
            Price = price;
            Description = description;
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
