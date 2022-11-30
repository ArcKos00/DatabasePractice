using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Shipper
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public Order Order { get; set; } = null!;
    }
}
