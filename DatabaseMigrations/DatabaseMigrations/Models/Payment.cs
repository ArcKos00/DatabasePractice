using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string? PaymentType { get; set; }
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
        public bool Allowed { get; set; }
    }
}
