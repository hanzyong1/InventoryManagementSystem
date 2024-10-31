using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> Get(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            return category;
        }

        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
