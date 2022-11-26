using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Category
    {
        public string? CategoryName { get; set; }
        public bool? Active { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
