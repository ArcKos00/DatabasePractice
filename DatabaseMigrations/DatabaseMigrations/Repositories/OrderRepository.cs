using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using DatabaseMigrations.Services.Abstractions;
using DatabaseMigrations.Repositories.Abstractions;

namespace DatabaseMigrations.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(IDbContextWrapper<ApplicationDbContext> wrapper)
        {
            _dbContext = wrapper.DbContext;
        }

        public async Task<int> AddOrderAsync(OrderEntity order)
        {
            var id = await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return id.Entity.Id;
        }

        public async Task<int> AddOrderAsync(CustomerEntity customer, ShipperEntity shipper, PaymentEntity pay, int orderNumber, List<OrderDetailEntity> orderDetails, bool paid = false)
        {
            var order = await _dbContext.Orders.AddAsync(new OrderEntity()
            {
                CustomerId = customer.Id,
                OrderNumber = orderNumber,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                Paid = paid,
                PaymentId = pay.Id,
                ShipperId = shipper.Id,
                Pay = pay,
                Customer = customer,
                Shipper = shipper
            });

            await _dbContext.OrderDetails.AddRangeAsync(orderDetails.Select(s => new OrderDetailEntity()
            {
                OrderId = order.Entity.Id,
                ProductId = s.ProductId,
                Price = s.Price,
                Discount = s.Discount,
                Total = s.Total,
                Id = s.Id,
                OrderNumber = s.OrderNumber,
                Product = s.Product,
                Order = s.Order
            }));

            await _dbContext.SaveChangesAsync();
            return order.Entity.Id;
        }

        public async Task<OrderEntity?> GetOrderAsync(int orderId)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(f => f.Id == orderId);
        }

        public async Task<OrderEntity?> GetOrderWithDetailsAsync(int orderId)
        {
            return await _dbContext.Orders.Include(i => i.Details).FirstOrDefaultAsync(f => f.Id == orderId);
        }

        public async Task<bool> UpdateOrderDataAsync(int orderId, OrderEntity newEntity)
        {
            var entity = await GetOrderAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderCustomerIdAsync(int orderId, int customerId)
        {
            var entity = await GetOrderAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            entity.CustomerId = customerId;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderOrderNumberAsync(int orderId, int orderNumber)
        {
            var entity = await GetOrderAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            entity.OrderNumber = orderNumber;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderOrderDateAsync(int orderId, DateOnly date)
        {
            var entity = await GetOrderAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            entity.OrderDate = date;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderPaymentIdAsync(int orderId, int paymnetId)
        {
            var entity = await GetOrderAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            entity.PaymentId = paymnetId;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderPaidAsync(int orderId, bool paid)
        {
            var entity = await GetOrderAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            entity.Paid = paid;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderShippersIdAsync(int orderId, int shipperId)
        {
            var entity = await GetOrderAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            entity.ShipperId = shipperId;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var entity = await GetOrderAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
