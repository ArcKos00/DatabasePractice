﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; } = string.Empty;
        public string? ContactFName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
