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

        public async Task<int> AddOrderDetailsAsync(decimal price, float discount, OrderEntity details, ProductEntity product)
        {
            var orderDetail = new OrderDetailEntity()
            {
                Price = price,
                Discount = discount,
                ProductId = product.ProductId,
                OrderId = details.OrderId
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
