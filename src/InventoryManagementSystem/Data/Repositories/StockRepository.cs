using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock?> Get(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Stock>> GetAllByProductId(int productId)
        {
            return await _context.Stocks
                .Include(e => e.Warehouse)
                .Where(e => e.ProductId == productId)
                .ToListAsync();
        }

        public async Task<List<Stock>> GetAll()
        {
            return await _context.Stocks.ToListAsync();
        }
    }
}
