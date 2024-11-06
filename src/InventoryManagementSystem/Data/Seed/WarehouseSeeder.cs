using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data.Seed
{
    public class WarehouseSeeder
    {
        private readonly ApplicationDbContext _context;

        public WarehouseSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        private static List<Warehouse> GetInitialWarehouses()
        {
            return new List<Warehouse>()
            {
                new Warehouse() { Name = "Warehouse 1", Location = "Location 1" },
                new Warehouse() { Name = "Warehouse 2", Location = "Location 2" },
            };
        }

        public async Task Create()
        {
            if (!_context.Warehouses.Any())
            {
                await _context.Warehouses.AddRangeAsync(GetInitialWarehouses());
                await _context.SaveChangesAsync();
            }
        }
    }
}
