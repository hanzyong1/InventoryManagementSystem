
namespace InventoryManagementSystem.Data.Seed
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            await new CategorySeeder(context).Create();
            await new ProductSeeder(context).Create();
        }
    }
}
