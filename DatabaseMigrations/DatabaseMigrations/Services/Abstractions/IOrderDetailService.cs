using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface IOrderDetailService
    {
        public Task<int> AddOrderDetailsAsync(OrderDetail detail);
        public Task<int> AddOrderDetailsAsync(float price, float discount, Order order, Product product);
        public Task<OrderDetail?> GetOrderDetailsAsync(int detailId);
        public Task<OrderDetail?> GetOrderDetailsWithChildAsync(int detailId);
        public Task UpdateDataAsync(int detailId, OrderDetail detail);
        public Task UpdateOrderIdAsync(int detailId, int orderId);
        public Task UpdateProductIdAsync(int detailId, int productId);
        public Task UpdatePriceAsync(int detailId, float price);
        public Task UpdateDiscountAsync(int detailId, float discount);
        public Task UpdateTotalAsync(int detailId, float total);
        public Task DeleteDetailsAsync(int id);
    }
}
