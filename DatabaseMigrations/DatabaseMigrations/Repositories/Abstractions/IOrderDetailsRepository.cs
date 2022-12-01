using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IOrderDetailsRepository
    {
        public Task<int> AddOrderDetailsAsync(OrderDetailEntity details);
        public Task<int> AddOrderDetailsAsync(float price, float discount, OrderEntity order, ProductEntity product);
        public Task<OrderDetailEntity?> GetOrderDetailAsync(int detailsId);
        public Task<OrderDetailEntity?> GetOrderDetailWithProductAsync(int detailsId);
        public Task<bool> UpdateDetailDataAsync(int entityId, CustomerEntity newEntity);
        public Task<bool> UpdateDetailOrderIdAsync(int entityId, int orderId);
        public Task<bool> UpdateDetailProductIdAsync(int entityId, int productId);
        public Task<bool> UpdatePriceAsync(int entityId, float price);
        public Task<bool> UpdateDiscountAsync(int entityId, float discount);
        public Task<bool> UpdateTotalAsync(int entityId, float total);
        public Task<bool> DeleteOrderDetailsAsync(int detailId);
    }
}
