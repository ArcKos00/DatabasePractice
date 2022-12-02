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
        public Task<int> AddOrderAsync(Order order);
        public Task<int> AddOrderAsync(Customer customer, IEnumerable<OrderDetail> orderDetails, Shipper shipper, Payment pay, int orderNumber);
        public Task<Order?> GetOrderAsync(int orderId);
        public Task<Order?> GetOrderWithChildAsync(int orderId);
        public Task UpdateOrderDataAsync(int orderId, Order order);
        public Task UpdateCustomerIdAsync(int orderId, int customerId);
        public Task UpdateOrderNumberAsync(int orderId, int orderomber);
        public Task UpdateOrderDateAsync(int orderId, DateOnly date);
        public Task UpdatePaymentIdAsync(int orderId, int paymentId);
        public Task UpdatePaidAsync(int orderId, bool paid);
        public Task UpdateShipperIdAsync(int orderId, int shipperId);
        public Task DeleteOrderAsycn(int orderId);
    }
}
