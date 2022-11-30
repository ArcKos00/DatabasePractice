using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class SupplierEntity
    {
        public int SupplierId { get; set; }
        public string? CompanyName { get; set; } = string.Empty;
        public string? ContactFName { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public List<ProductEntity> ProductList { get; set; } = new List<ProductEntity>();
    }
}
