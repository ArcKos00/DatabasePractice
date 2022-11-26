using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;

namespace DatabaseMigrations.Repositories
{
    public class OrderDetaisRepository : IOrderDetailsRepository
    {
        public Task<string> AddOrderDetailsAsync(decimal price, float discount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailEntity?> GetOrderDetailByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderDetailsAsync(string id, OrderDetailEntity orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
