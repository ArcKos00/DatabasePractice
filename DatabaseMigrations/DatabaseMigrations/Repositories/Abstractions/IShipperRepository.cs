using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IShipperRepository
    {
        public Task<int> AddShipperAsync(ShipperEntity shipper);
        public Task<int> AddShipperAsync(string name, string phone, List<OrderEntity> orders);
        public Task<ShipperEntity?> GetShipperAsync(int entityId);
        public Task<List<OrderEntity>?> GetShipperOrdersAsync(int entityId);
        public Task<bool> UpdateShipperDataAsync(int entityId, ShipperEntity newEntity);
        public Task<bool> UpdateShipperNameAsync(int entityId, string companyName);
        public Task<bool> UpdateShipperPhoneAsync(int entityId, string phone);
        public Task<bool> DeleteShipperAsync(int entityId);
    }
}
