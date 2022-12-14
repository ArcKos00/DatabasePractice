using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public CustomerEntity? Customer { get; set; } = null;

        public int OrderNumber { get; set; }
        public List<OrderDetailEntity> Details { get; set; } = new List<OrderDetailEntity>();
        public DateOnly OrderDate { get; set; }

        public int PaymentId { get; set; }
        public PaymentEntity Pay { get; set; } = null!;
        public bool Paid { get; set; }

        public int ShipperId { get; set; }
        public ShipperEntity Shipper { get; set; } = null!;
    }
}
