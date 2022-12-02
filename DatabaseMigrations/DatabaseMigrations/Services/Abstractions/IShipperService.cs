using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface IShipperService
    {
        public Task<int> AddShipperAsync(Shipper shipper);
        public Task<int> AddShipperAsync(string name, string phone, IEnumerable<Order> orders);
        public Task<Shipper?> GetShipperAsync(int shipperId);
        public Task<Shipper?> GetShipperWithChildAsync(int shipperId);
        public Task UpdateShipperDateAsync(int shipperId, Shipper newEntity);
        public Task UpdateNameAsync(int shipperId, string newName);
        public Task UpdatePhoneAsync(int shipperId, string newPhone);
        public Task DeleteShipperAsync(int shipperId);
    }
}
