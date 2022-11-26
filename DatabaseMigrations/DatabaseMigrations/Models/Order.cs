using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Order
    {
        public Customer? CustomerOrder { get; set; }
        public int OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool Paid { get; set; }
        public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }
}
