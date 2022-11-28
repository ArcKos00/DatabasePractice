using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class CustomerEntity
    {
        public string CustomerId { get; set; } = string.Empty;
        public List<OrderEntity> OrderList { get; set; } = new List<OrderEntity>();

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address1 { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime DateEntered { get; set; }
    }
}
