using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Suppliers
    {
        public int SupplierId { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactFName { get; set; }
        public string? ContactLName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? URL { get; set; }
        public string? PaymentMethods { get; set; }
        public string? DiscountType { get; set; }
        public string? TypeGoods { get; set; }
        public string? Notes { get; set; }
        public bool DiscountAvailable { get; set; }
        public string? CurrentOrder { get; set; }
        public string? Logo { get; set; }
        public int CustomerId { get; set; }
        public int SizeURL { get; set; }
        public List<Products> ProductList { get; set; } = new List<Products>();
    }
}
