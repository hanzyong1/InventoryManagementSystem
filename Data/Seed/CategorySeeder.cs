using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Seed
{
    public class CategorySeeder
    {
        private readonly ApplicationDbContext _context;

        public CategorySeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        private static List<Category> GetInitialCategories()
        {
            return new List<Category>()
            {
                new Category() { Name = "Electronics" },
                new Category() { Name = "Fashion" },
                new Category() { Name = "Food" },
                new Category() { Name = "DIY and hardware items" },
                new Category() { Name = "Furniture" },
                new Category() { Name = "Beauty and personal care" },
            };
        }

        public async Task Create()
        {
            if (!_context.Categories.Any())
            {
                await _context.Categories.AddRangeAsync(GetInitialCategories());
                await _context.SaveChangesAsync();
            }
        }
    }
}
