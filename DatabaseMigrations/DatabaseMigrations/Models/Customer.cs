using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Customer
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<string> Address { get; set; } = new List<string>();
        public string? Phone { get; set; }
        public List<Order> OrderList { get; set; } = new List<Order>();
    }
}
