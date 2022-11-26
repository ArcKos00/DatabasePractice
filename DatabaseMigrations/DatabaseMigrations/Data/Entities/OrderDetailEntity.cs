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
        public OrderEntity? Order { get; set; }

        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }

        public int OrderNumber { get; set; }
        public decimal Price { get; set; }
        public string? Quantify { get; set; }
        public float Discount { get; set; }
        public decimal Total { get; set; }
        public int IdSKU { get; set; }
        public int Size { get; set; }
        public string? Color { get; set; }
        public bool Fulfilled { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }
    }
}
