using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerOrder { get; set; } = null!;
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;
        public bool Paid { get; set; }
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; } = null!;
        public IEnumerable<OrderDetail>? Details { get; set; }
    }
}
