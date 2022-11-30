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

        public async Task<int> AddOrderAsync(int customerId, int shipperId, int payId, int orderNumber, List<OrderDetailEntity> orderDetails, bool paid = false)
        {
            var order = await _dbContext.Orders.AddAsync(new OrderEntity()
            {
                CustomerId = customerId,
                OrderNumber = orderNumber,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                Paid = paid,
                PaymentId = payId,
                ShipperId = shipperId
            });

            await _dbContext.OrderDetails.AddRangeAsync(orderDetails.Select(s => new OrderDetailEntity()
            {
                OrderId = order.Entity.OrderId,
                ProductId = s.ProductId,
                Price = s.Price,
                Discount = s.Discount,
                Total = s.Total,
                OrderDetailId = s.OrderDetailId,
                OrderNumber = s.OrderNumber,
                Product = s.Product,
                Order = s.Order
            }));

            await _dbContext.SaveChangesAsync();
            return order.Entity.OrderId;
        }

        public async Task<OrderEntity?> GetOrderByIdAsync(int orderId)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(f => f.OrderId == orderId);
        }

        public async Task<bool> UpdateOrderAsync(int orderId, OrderEntity newEntity)
        {
            var entity = await GetOrderByIdAsync(orderId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
