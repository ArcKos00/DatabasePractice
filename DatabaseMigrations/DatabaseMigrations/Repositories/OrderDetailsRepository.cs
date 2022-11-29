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

        public async Task<int> AddOrderDetailsAsync(decimal price, float discount, decimal total, int orderId, int productId)
        {
            var orderDetail = new OrderDetailEntity()
            {
                Price = price,
                Discount = discount,
                Total = total,
                OrderNumber = orderId,
                ProductId = productId,
                OrderId = orderId
            };

            await _dbContext.AddAsync(orderDetail);
            await _dbContext.SaveChangesAsync();

            return orderDetail.OrderDetailId;
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
