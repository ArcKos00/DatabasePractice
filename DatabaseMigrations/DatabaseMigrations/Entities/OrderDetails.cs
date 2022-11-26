using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }
        public Orders? Order { get; set; }

        public int ProductId { get; set; }
        public Products? Product { get; set; }

        public int OrderNumber { get; set; }
        public decimal Price { get; set; }
        public string? Quantify { get; set; }
        public float Discount { get; set; }
        public decimal Total { get; set; }
        public int IdSKU { get; set; }
        public int Size { get; set; }
        public string? Color { get; set; }
        public bool FullFilled { get; set; }
        public DateTime ShipDate { get; set; }

        // dd
        public DateTime BillId { get; set; }
    }
}
