using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDiscription { get; set; }

        public int SupplierId { get; set; }
        public SupplierEntity? Supplier { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }

        public decimal UnitPrice { get; set; }
        public float Discount { get; set; }
        public float UnitWeight { get; set; }
        public bool ProductAvailable { get; set; }
        public bool DiscountAvailable { get; set; }

        public int CurrentOrder { get; set; }
        public List<OrderDetailEntity> Details { get; set; } = new List<OrderDetailEntity>();

        public byte[] Picture { get; set; } = new byte[0];
    }
}