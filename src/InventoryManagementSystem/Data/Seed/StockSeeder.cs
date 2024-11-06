using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Seed
{
    public class StockSeeder
    {
        private readonly ApplicationDbContext _context;

        public StockSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        private static List<Stock> GetInitialStocks()
        {
            return new List<Stock>()
            {
                new Stock() { WarehouseId = 1, ProductId = 1, Quantity = 100 },
                new Stock() { WarehouseId = 1, ProductId = 2, Quantity = 200 },
                new Stock() { WarehouseId = 2, ProductId = 3, Quantity = 300 },
                new Stock() { WarehouseId = 2, ProductId = 4, Quantity = 400 },
                new Stock() { WarehouseId = 1, ProductId = 5, Quantity = 500 },
                new Stock() { WarehouseId = 2, ProductId = 5, Quantity = 500 },
                new Stock() { WarehouseId = 1, ProductId = 6, Quantity = 600 },
                new Stock() { WarehouseId = 2, ProductId = 6, Quantity = 600 },
            };
        }

        public async Task Create()
        {
            if (!_context.Stocks.Any())
            {
                await _context.Stocks.AddRangeAsync(GetInitialStocks());
                await _context.SaveChangesAsync();
            }
        }
    }
}
