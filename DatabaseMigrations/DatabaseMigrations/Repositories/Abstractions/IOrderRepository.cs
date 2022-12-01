using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        public Task<int> AddOrderAsync(OrderEntity order);
        public Task<int> AddOrderAsync(CustomerEntity customer, ShipperEntity shipper, PaymentEntity pay, int orderNumber, List<OrderDetailEntity> orderDetails, bool paid = false);
        public Task<OrderEntity?> GetOrderAsync(int orderId);
        public Task<OrderEntity?> GetOrderWithDetailsAsync(int orderId);
        public Task<bool> UpdateOrderDataAsync(int orderId, OrderEntity newEntity);
        public Task<bool> UpdateOrderCustomerIdAsync(int orderId, int customerId);
        public Task<bool> UpdateOrderOrderNumberAsync(int orderId, int orderNumber);
        public Task<bool> UpdateOrderOrderDateAsync(int orderId, DateOnly date);
        public Task<bool> UpdateOrderPaymentIdAsync(int orderId, int paymnetId);
        public Task<bool> UpdateOrderPaidAsync(int orderId, bool paid);
        public Task<bool> UpdateOrderShippersIdAsync(int orderId, int shipperId);
        public Task<bool> DeleteOrder(int orderId);
    }
}
