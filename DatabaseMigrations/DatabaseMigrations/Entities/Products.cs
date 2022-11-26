using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Products
    {
        public int ProductId { get; set; }
        public string? SKU { get; set; }
        public int IdSKU { get; set; }

        // dd
        public int VeridorProductsId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDiscription { get; set; }

        public int SupplierId { get; set; }
        public Suppliers? Supplier { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }

        // dd
        public string? MSRP { get; set; }
        public string? AvailableSize { get; set; }
        public string? AvailableColors { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public float Discount { get; set; }
        public float UnitWeight { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrders { get; set; }

        // dd
        public string? ReorderLevel { get; set; }
        public bool ProductAvailable { get; set; }
        public bool DiscountAvailable { get; set; }

        public int CurrentOrder { get; set; }
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        public byte[] Picture { get; set; } = new byte[0];

        // dd
        public int Ranking { get; set; }
        public string? Note { get; set; }
    }
}