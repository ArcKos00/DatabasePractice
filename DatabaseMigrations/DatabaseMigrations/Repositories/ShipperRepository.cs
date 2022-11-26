using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;

namespace DatabaseMigrations.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        public Task<string> AddShipperAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteShipperAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ShipperEntity?> GetShipperByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateShipperAsync(string id, ShipperEntity payment)
        {
            throw new NotImplementedException();
        }
    }
}
