using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class OrderDetailEntity
    {
        public string OrderDetailId { get; set; } = string.Empty;

        public int OrderId { get; set; }
        public OrderEntity? Order { get; set; }

        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }

        public int OrderNumber { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public decimal Total { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }
    }
}
