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

        public async Task<int> AddOrderDetailsAsync(float price, float discount, OrderEntity order, ProductEntity product)
        {
            var orderDetail = await _dbContext.OrderDetails.AddAsync(new OrderDetailEntity()
            {
                Price = price,
                Discount = discount,
                Total = price * (discount / 100),
                OrderNumber = order.OrderNumber,
                ProductId = product.ProductId,
                OrderId = order.OrderId,
                Order = order,
                Product = product
            });
            await _dbContext.SaveChangesAsync();
            return orderDetail.Entity.OrderDetailId;
        }

        public async Task<bool> DeleteOrderDetailsAsync(int detailId)
        {
            var details = await GetOrderDetailByIdAsync(detailId);
            if (details == null)
            {
                return false;
            }

            _dbContext.Entry(details).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<OrderDetailEntity?> GetOrderDetailByIdAsync(int detailsId)
        {
            return await _dbContext.OrderDetails.Include(i => i.Order).Include(i => i.Product).FirstOrDefaultAsync();
        }
    }
}
