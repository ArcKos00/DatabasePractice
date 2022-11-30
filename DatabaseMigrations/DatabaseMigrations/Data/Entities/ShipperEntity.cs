using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class ShipperEntity
    {
        public int ShipperId { get; set; }
        public List<OrderEntity> OrderList { get; set; } = new List<OrderEntity>();

        public string? CompanyName { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
    }
}
