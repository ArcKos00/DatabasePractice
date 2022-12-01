using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDetailsRepository(IDbContextWrapper<ApplicationDbContext> wrapper)
        {
            _dbContext = wrapper.DbContext;
        }

        public async Task<int> AddOrderDetailsAsync(OrderDetailEntity details)
        {
            var entity = await _dbContext.OrderDetails.AddAsync(details);
            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<int> AddOrderDetailsAsync(float price, float discount, OrderEntity order, ProductEntity product)
        {
            var orderDetail = await _dbContext.OrderDetails.AddAsync(new OrderDetailEntity()
            {
                Price = price,
                Discount = discount,
                OrderNumber = order.OrderNumber,
                ProductId = product.Id,
                OrderId = order.Id,
                Order = order,
                Product = product
            });
            await _dbContext.SaveChangesAsync();
            return orderDetail.Entity.Id;
        }

        public async Task<OrderDetailEntity?> GetOrderDetailAsync(int detailsId)
        {
            return await _dbContext.OrderDetails.Include(i => i.Order).FirstOrDefaultAsync();
        }

        public async Task<OrderDetailEntity?> GetOrderDetailWithProductAsync(int detailsId)
        {
            return await _dbContext.OrderDetails.Include(i => i.Order).Include(i => i.Product).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateTotalAsync(int entityId, float total)
        {
            var entity = await GetOrderDetailAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Total = total;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePriceAsync(int entityId, float price)
        {
            var entity = await GetOrderDetailAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Price = price;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDiscountAsync(int entityId, float discount)
        {
            var entity = await GetOrderDetailAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Discount = discount;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDetailDataAsync(int entityId, CustomerEntity newEntity)
        {
            var entity = await GetOrderDetailAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDetailOrderIdAsync(int entityId, int orderId)
        {
            var entity = await GetOrderDetailAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.OrderId = orderId;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDetailProductIdAsync(int entityId, int productId)
        {
            var entity = await GetOrderDetailAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.ProductId = productId;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderDetailsAsync(int detailId)
        {
            var details = await GetOrderDetailAsync(detailId);
            if (details == null)
            {
                return false;
            }

            _dbContext.Entry(details).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
