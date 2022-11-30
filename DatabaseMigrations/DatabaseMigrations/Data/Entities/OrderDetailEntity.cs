using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class OrderDetailEntity
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;

        public int OrderNumber { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }
    }
}
