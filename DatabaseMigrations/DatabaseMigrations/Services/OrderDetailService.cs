using System;
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

        public async Task<int> AddOrderDetailsAsync(decimal price, float discount, Order order, Product product)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _orderDetailRepository.AddOrderDetailsAsync(
                price,
                discount,
                new OrderEntity()
                {
                    OrderId = order.Id,
                    CustomerId = order.CustomerOrder!.Id,
                    OrderNumber = order.OrderNumber,
                    OrderDate = order.OrderDate,
                    PaymentId = order.Payment!.Id,
                    Paid = order.Paid,
                },
                new ProductEntity()
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    SupplierId = product.TheseSupplier!.Id,
                    CategoryId = product.CategoryId,
                    UnitPrice = product.Price,
                    Discount = product.Discount,
                });
            });
        }

        public async Task<OrderDetail>? GetOrderDetailsAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _orderDetailRepository.GetOrderDetailByIdAsync(id);
                if (result == null)
                {
                    _logger.LogError($"Cannot found OrderDetails with id: {id}");
                    return null!;
                }

                return new OrderDetail()
                {
                    Id = result.OrderDetailId,
                    Price = result.Price,
                    Discount = result.Discount,
                    Total = result.Total,
                    ProductInOrder = new Product()
                    {
                        Id = result.OrderDetailId,
                        ProductName = result.Product!.ProductName,
                        CategoryId = result.Product!.CategoryId,
                        Price = result.Price,
                        Discount = result.Discount,
                    }
                };
            });
        }

        public async Task DeleteDetailsAsync(int id)
        {
            var result = await _orderDetailRepository.DeleteOrderDetailsAsync(id);
            if (result == false)
            {
                _logger.LogError("Cannot delete this Details");
            }
        }
    }
}
