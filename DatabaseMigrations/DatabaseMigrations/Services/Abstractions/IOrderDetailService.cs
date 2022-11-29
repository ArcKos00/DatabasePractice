using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface IOrderDetailService
    {
        public Task<int> AddOrderDetailsAsync(decimal price, float discount, decimal total, int order, int product);
        public Task<OrderDetail>? GetOrderDetailsAsync(int id);
        public Task DeleteDetailsAsync(int id);
    }
}
