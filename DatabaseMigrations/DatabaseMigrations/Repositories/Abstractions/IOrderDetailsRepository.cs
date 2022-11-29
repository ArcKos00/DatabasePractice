﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IOrderDetailsRepository
    {
        public Task<int> AddOrderDetailsAsync(decimal price, float discount, decimal total, int orderID, int productId);
        public Task<OrderDetailEntity?> GetOrderDetailByIdAsync(int detailId);
        public Task<bool> DeleteOrderDetailsAsync(int detailId);
    }
}
