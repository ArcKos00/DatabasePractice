using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class CustomerEntity
    {
        public string CustomerId { get; set; } = string.Empty;
        public List<OrderEntity> OrderList { get; set; } = new List<OrderEntity>();

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Class { get; set; }
        public string? Room { get; set; }
        public string? Building { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? VoiseMail { get; set; }
        public string? Password { get; set; }
        public string? CreditCard { get; set; }
        public int CreditCardTypeId { get; set; }
        public string? CardExpMo { get; set; }
        public string? CardExpYr { get; set; }
        public string? BuildingAddress { get; set; }
        public string? BuildingCity { get; set; }
        public string? BuildingRegion { get; set; }
        public int BuildingPostalCode { get; set; }
        public string? BuildingCountry { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public int ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        public DateTime DateEntered { get; set; }
    }
}
