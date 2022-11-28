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
    public class OrderDetaisRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDetaisRepository(IDbContextWrapper<ApplicationDbContext> wrapper)
        {
            _dbContext = wrapper.DbContext;
        }

        public async Task<string> AddOrderDetailsAsync(decimal price, float discount, OrderEntity details, ProductEntity product)
        {
            var orderDetail = new OrderDetailEntity()
            {
                OrderDetailId = Guid.NewGuid().ToString(),
                Price = price,
                Discount = discount,
                ProductId = product.ProductId,
                OrderId = details.OrderId,
            };

            await _dbContext.AddAsync(orderDetail);
            await _dbContext.SaveChangesAsync();

            return orderDetail.OrderDetailId;
        }

        public async Task<bool> DeleteOrderDetailsAsync(string detailId)
        {
            var details = await _dbContext.OrderDetails.FirstOrDefaultAsync(f => f.OrderDetailId == detailId);
            if (details == null)
            {
                return false;
            }

            _dbContext.Remove(details);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<OrderDetailEntity?> GetOrderDetailByIdAsync(string id)
        {
            return await _dbContext.OrderDetails.Include(i => i.Order).Include(i => i.Product).FirstOrDefaultAsync();
        }

        public Task<bool> UpdateOrderDetailsAsync(string id, OrderDetailEntity orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
