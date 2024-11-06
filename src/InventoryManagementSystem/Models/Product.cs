using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(string name, int categoryId, string? description = null, double price = 0.0)
        {
            Name = name;
            CategoryId = categoryId;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
