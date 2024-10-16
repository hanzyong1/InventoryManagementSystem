

using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Seed
{
    public class ProductSeeder
    {
        private readonly ApplicationDbContext _context;

        public ProductSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        private static List<Product> GetInitialProducts()
        {
            return new List<Product>
            {
                //Electronics
                new Product() { Name = "Smartphone", Description = null, CategoryId = 1, Quantity = 2, Price = 1.10 },
                new Product() { Name = "Wireless Headphone", Description = null, CategoryId = 1, Quantity = 2, Price = 1.10 },

                //Fashion
                new Product() { Name = "Sneakers", Description = null, CategoryId = 2, Quantity = 2, Price = 2.20 },
                new Product() { Name = "Dress", Description = null, CategoryId = 2, Quantity = 2, Price = 2.20 },

                //Food
                new Product() { Name = "Organic Snack Bars", Description = null, CategoryId = 3, Quantity = 2, Price = 3.30 },
                new Product() { Name = "Olive Oil", Description = null, CategoryId = 3, Quantity = 2, Price = 3.30 },

                //DIY and hardware items
                new Product() { Name = "Cordless Drill", Description = null, CategoryId = 4, Quantity = 2, Price = 4.40 },
                new Product() { Name = "Paint Set", Description = null, CategoryId = 4, Quantity = 2, Price = 4.40 },

                //Furniture
                new Product() { Name = "Office Chair", Description = null, CategoryId = 5, Quantity = 2, Price = 5.50 },
                new Product() { Name = "Sofa", Description = null, CategoryId = 5, Quantity = 2, Price = 5.50 },

                //Beauty and personal care
                new Product() { Name = "Moisturizer", Description = null, CategoryId = 6, Quantity = 2, Price = 6.60 },
                new Product() { Name = "Makeup Palette", Description = null, CategoryId = 6, Quantity = 2, Price = 6.60 },
            };
        }

        public async Task Create()
        {
            if (!_context.Products.Any())
            {
                await _context.Products.AddRangeAsync(GetInitialProducts());
                await _context.SaveChangesAsync();
            }
        } 
    }
}
