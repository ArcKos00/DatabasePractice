using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class ShipperEntity
    {
        public int Id { get; set; }
        public List<OrderEntity> OrderList { get; set; } = new List<OrderEntity>();

        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
    }
}
