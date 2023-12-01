using InventoryManagementSystem.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class InventoryManagementSystemDbContext : DbContext
    {
        public InventoryManagementSystemDbContext(DbContextOptions<InventoryManagementSystemDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductOwner> ProductOwners { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
    }
}
