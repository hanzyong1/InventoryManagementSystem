using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(1000)]
        public string Name { get; set; }

        [Required]
        [MinLength(100), MaxLength(8000)]
        public string Description { get; set; }

        [Range(5, 9000)]
        public decimal Price { get; set; }
        public DateTime AvailableSince { get; set; }
        public DateTime CreatedDate { get; set; }

        [MaxLength(200)]
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [MaxLength(200)]
        public string ModifiedBy { get; set;}
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? ProductOwnerId { get; set; }
        public ProductOwner ProductOwner { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }

    public class ProductImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Mime { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
