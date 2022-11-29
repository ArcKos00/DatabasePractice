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
        public Task<int> AddOrderAsync(int customerId, int shipperId, int payId, int ordernumber, bool paid, List<OrderDetailEntity> orderDetails);
        public Task<OrderEntity?> GetOrderByIdAsync(int id);
        public Task<bool> UpdateOrderAsync(int orderId, OrderEntity orderDetails);
    }
}
