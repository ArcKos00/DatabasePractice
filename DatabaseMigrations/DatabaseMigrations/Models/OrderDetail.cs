using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product ProductInOrder { get; set; } = null!;
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int OrderNumber { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public decimal Total { get; set; }
    }
}
