using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public List<OrderEntity> OrderList { get; set; } = new List<OrderEntity>();

        public string? PaymentType { get; set; }
        public bool Allowed { get; set; }
    }
}
