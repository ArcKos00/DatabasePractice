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
        public Customer? CustomerOrder { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Payment? Payment { get; set; }
        public bool Paid { get; set; }
        public Shipper? Shipper { get; set; }
        public IEnumerable<OrderDetail>? Details { get; set; }
    }
}
