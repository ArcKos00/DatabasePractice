using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class SupplierEntity
    {
        public string? SupplierId { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactFName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? CurrentOrder { get; set; }
        public string? CustomerId { get; set; }
        public List<ProductEntity> ProductList { get; set; } = new List<ProductEntity>();
    }
}
