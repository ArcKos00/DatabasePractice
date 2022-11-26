using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class OrderDetail
    {
        public Product? ProductInOrder { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public decimal Total { get; set; }
    }
}
