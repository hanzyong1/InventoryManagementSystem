using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }

        [MaxLength(200)]
        public string OwnerADObjectId { get; set; }
    }
}
