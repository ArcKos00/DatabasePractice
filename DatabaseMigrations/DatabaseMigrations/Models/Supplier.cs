using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactFName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
