using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; } = string.Empty;
        public string? Discription { get; set; } = string.Empty;
        public bool Active { get; set; }

        public List<ProductEntity> ProductsList { get; set; } = new List<ProductEntity>();
    }
}
