namespace InventoryManagementSystem.Models
{
    public class Category
    {
        public Category()
        {
            
        }
        public Category(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
