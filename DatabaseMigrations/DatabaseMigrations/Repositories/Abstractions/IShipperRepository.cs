using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IShipperRepository
    {
        public Task<int> AddShipperAsync(string name, string phone, List<OrderEntity> orders);
        public Task<ShipperEntity?> GetShipperByIdAsync(int id);
        public Task<bool> UpdateShipperAsync(int id, ShipperEntity payment);
        public Task<bool> DeleteShipperAsync(int id);
    }
}
