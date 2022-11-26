using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Payment
    {
        public string? PaymentType { get; set; }
        public bool? Allowed { get; set; }
    }
}
