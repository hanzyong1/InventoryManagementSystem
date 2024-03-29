﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1), MaxLength(500)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
