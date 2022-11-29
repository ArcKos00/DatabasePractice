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
        public Task<int> AddShipperAsync(string name, string phone, IEnumerable<Order> orders);
        public Task<Shipper?> GetShipperByIdAsync(int id);
        public Task UpdateShipperAsync(int id, Shipper ship);
        public Task DeleteShipperAsync(int id);
    }
}
