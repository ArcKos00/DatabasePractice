using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public Supplier? TheseSupplier { get; set; }
    }
}
