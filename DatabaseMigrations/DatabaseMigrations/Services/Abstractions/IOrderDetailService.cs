using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface IOrderDetailService
    {
        public Task<int> AddOrderDetailsAsync(float price, float discount, Order order, Product product);
        public Task<OrderDetail>? GetOrderDetailsAsync(int id);
        public Task DeleteDetailsAsync(int id);
    }
}
