using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigrations.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public bool Active { get; set; }
        public string? Discription { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
