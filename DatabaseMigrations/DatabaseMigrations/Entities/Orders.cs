using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Orders
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public Customers? Customer { get; set; }

        public int OrderNumber { get; set; }
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();
        public DateTime OrderDate { get; set; }

        public int PaymentId { get; set; }
        public Payment? Pay { get; set; }

        public int ShipperId { get; set; }
        public Shippers? Shipper { get; set; }
        public DateTime ShipDate { get; set; }

        public DateTime RequiredDate { get; set; }
        public string? Freight { get; set; }

        // dd
        public string? SailesTax { get; set; }
        public string? TimeStamp { get; set; }
        public string? TransactStatus { get; set; }
        public string? ErrLoc { get; set; }
        public string? ErrMag { get; set; }

        // dd
        public bool FullFilled { get; set; }
        public bool Deleted { get; set; }
        public bool Paid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
