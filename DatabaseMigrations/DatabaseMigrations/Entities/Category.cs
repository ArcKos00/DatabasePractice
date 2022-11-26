using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Discription { get; set; }
        public byte[] Picture { get; set; } = new byte[0];
        public bool Active { get; set; }

        public List<Products> ProductsList { get; set; } = new List<Products>();
    }
}
