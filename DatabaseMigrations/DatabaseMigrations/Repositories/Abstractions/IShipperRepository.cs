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
        public Task<string> AddShipperAsync();
        public Task<ShipperEntity?> GetShipperByIdAsync(string id);
        public Task<bool> UpdateShipperAsync(string id, ShipperEntity payment);
        public Task<bool> DeleteShipperAsync();
    }
}
