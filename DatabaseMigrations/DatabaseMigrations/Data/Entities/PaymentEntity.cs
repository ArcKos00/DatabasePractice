using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class PaymentEntity
    {
        public int PaymentId { get; set; }
        public List<OrderEntity> OrderList { get; set; } = new List<OrderEntity>();

        public string? PaymentType { get; set; } = string.Empty;
        public bool Allowed { get; set; }
    }
}
