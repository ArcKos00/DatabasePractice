using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Shippers
    {
        public int ShipperId { get; set; }
        public List<Orders> OrderList { get; set; } = new List<Orders>();

        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
    }
}
