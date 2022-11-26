using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public List<Orders> OrderList { get; set; } = new List<Orders>();

        public string? PaymentType { get; set; }
        public bool Allowed { get; set; }
    }
}
