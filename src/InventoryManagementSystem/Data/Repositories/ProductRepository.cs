using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> Get(int id)
        {
            return await _context.Products.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }
    }
}
