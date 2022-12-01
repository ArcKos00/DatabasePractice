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

        public async Task<int> AddOrderDetailsAsync(float price, float discount, Order order, Product product)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _orderDetailRepository.AddOrderDetailsAsync(
                    price,
                    discount,
                    new OrderEntity()
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        OrderNumber = order.OrderNumber,
                        OrderDate = order.OrderDate,
                        PaymentId = order.PaymentId,
                        Paid = order.Paid,
                        ShipperId = order.ShipperId
                    },
                    new ProductEntity()
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        ProductDiscription = product.ProductDescription,
                        SupplierId = product.Supplierid,
                        CategoryId = product.CategoryId,
                        UnitPrice = product.Price,
                        Discount = product.Discount,
                        ProductAvailable = product.Available,
                        CurrentOrder = product.CurrentOrder
                    });
            });
        }

        public async Task<OrderDetail>? GetOrderDetailsAsync(int id)
        {
            var result = await _orderDetailRepository.GetOrderDetailAsync(id);
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
                Id = result.Id,
                Discount = result.Discount,
                ProductId = result.ProductId,
                OrderNumber = result.OrderNumber,
                ProductInOrder = new Product()
                {
                    Id = result.ProductId,
                    ProductName = result.Product.ProductName,
                    CategoryId = result.Product.CategoryId,
                    Price = result.Price,
                    Discount = result.Discount,
                },
                Order = new Order()
                {
                    Id = result.OrderId,
                    CustomerId = result.Order.CustomerId,
                    OrderNumber = result.OrderNumber,
                    OrderDate = result.Order.OrderDate,
                    PaymentId = result.Order.PaymentId,
                    Paid = result.Order.Paid,
                    ShipperId = result.Order.ShipperId,
                }
            };
        }

        public async Task DeleteDetailsAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderDetailRepository.DeleteOrderDetailsAsync(id);
                if (!result)
                {
                    _logger.LogError("Cannot delete this Details");
                }
            });
        }
    }
}
