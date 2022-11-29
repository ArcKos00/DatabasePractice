﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services
{
    public class OrderDetailService : BaseDataService<ApplicationDbContext>, IOrderDetailService
    {
        private readonly IOrderDetailsRepository _orderDetailRepository;
        private readonly ILogger<OrderDetail> _logger;

        public OrderDetailService(
            ILogger<OrderDetail> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper,
            IOrderDetailsRepository repository)
            : base(wrapper, loggerService)
        {
            _orderDetailRepository = repository;
            _logger = logger;
        }

        public async Task<int> AddOrderDetailsAsync(decimal price, float discount, decimal total, int order, int product)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _orderDetailRepository.AddOrderDetailsAsync(price, discount, total, order, product);
            });
        }

        public async Task<OrderDetail>? GetOrderDetailsAsync(int id)
        {
            var result = await _orderDetailRepository.GetOrderDetailByIdAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found OrderDetails with id: {id}");
                return null!;
            }

            return new OrderDetail()
            {
                Total = result.Total,
                Price = result.Price,
                OrderId = result.OrderId,
                Id = result.OrderDetailId,
                Discount = result.Discount,
                ProductId = result.ProductId,
                OrderNumber = result.OrderNumber,
                ProductInOrder = new Product()
                {
                    Id = result.ProductId,
                    ProductName = result.Product!.ProductName,
                    CategoryId = result.Product!.CategoryId,
                    Price = result.Price,
                    Discount = result.Discount,
                },
                Order = new Order()
                {
                    Id = result.OrderId,
                    CustomerId = result.Order!.CustomerId,
                    OrderNumber = result.OrderNumber,
                    OrderDate = result.Order!.OrderDate,
                    PaymentId = result.Order!.PaymentId,
                    Paid = result.Order.Paid,
                    ShipperId = result.Order!.ShipperId,
                }
            };
        }

        public async Task DeleteDetailsAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderDetailRepository.DeleteOrderDetailsAsync(id);
                if (result == false)
                {
                    _logger.LogError("Cannot delete this Details");
                }
            });
        }
    }
}
