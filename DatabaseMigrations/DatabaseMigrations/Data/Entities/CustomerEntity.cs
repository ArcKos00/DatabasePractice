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

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adddres { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime DateEntered { get; set; }
    }
}
