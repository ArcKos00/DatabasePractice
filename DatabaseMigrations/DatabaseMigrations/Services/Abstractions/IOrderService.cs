using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface IOrderService
    {
        public Task<int> AddOrderAsync(int customerId, IEnumerable<OrderDetail> orderDetails, int shipperId, int payId, int orderNumber, bool paid);
        public Task<Order>? GetOrderASync(int id);
        public Task UpdateOrder(int id, Order order);
    }
}
