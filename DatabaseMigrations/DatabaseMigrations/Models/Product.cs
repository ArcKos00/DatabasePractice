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
        public string? ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public int Supplierid { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public bool Available { get; set; }
        public int CurrentOrder { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public IEnumerable<OrderDetail>? Details { get; set; }
    }
}
