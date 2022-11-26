using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IOrderDetailsRepository
    {
        public Task<string> AddOrderDetailsAsync(decimal price, float discount);
        public Task<OrderDetailEntity?> GetOrderDetailByIdAsync(string id);
        public Task<bool> UpdateOrderDetailsAsync(string id, OrderDetailEntity orderDetails);
        public Task<bool> DeleteOrderDetailsAsync();
    }
}
