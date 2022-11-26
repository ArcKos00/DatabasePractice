using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        public Task<string> AddOrderAsync();
        public Task<OrderEntity?> GetOrderByIdAsync(string id);
        public Task<bool> UpdateOrderAsync(string id, OrderEntity orderDetails);
        public Task<bool> DeleteOrderAsync();
    }
}
