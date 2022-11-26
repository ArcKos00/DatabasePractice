using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;

namespace DatabaseMigrations.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<string> AddOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity?> GetOrderByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderAsync(string id, OrderEntity orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
