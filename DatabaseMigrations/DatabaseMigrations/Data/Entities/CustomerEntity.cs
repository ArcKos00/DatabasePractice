using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public List<OrderEntity> OrderList { get; set; } = new List<OrderEntity>();

        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Address1 { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public DateOnly DateEntered { get; set; }
    }
}
