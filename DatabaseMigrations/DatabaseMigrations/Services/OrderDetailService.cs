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
        private readonly ILogger<OrderDetailService> _logger;

        public OrderDetailService(
            ILogger<OrderDetailService> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper,
            IOrderDetailsRepository repository)
            : base(wrapper, loggerService)
        {
            _orderDetailRepository = repository;
            _logger = logger;
        }

        public async Task<int> AddOrderDetailsAsync(OrderDetail detail)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _orderDetailRepository.AddOrderDetailsAsync(new OrderDetailEntity()
                {
                    Id = detail.Id,
                    Discount = detail.Discount,
                    OrderId = detail.OrderId,
                    OrderNumber = detail.OrderNumber,
                    Price = detail.Price,
                    ProductId = detail.ProductId,
                    Total = detail.Total
                });
            });
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
                        SupplierId = product.SupplierId,
                        CategoryId = product.CategoryId,
                        UnitPrice = product.Price,
                        Discount = product.Discount,
                        ProductAvailable = product.Available,
                        CurrentOrder = product.CurrentOrder
                    });
            });
        }

        public async Task<OrderDetail?> GetOrderDetailsAsync(int detailId)
        {
            var result = await _orderDetailRepository.GetOrderDetailAsync(detailId);
            if (result == null)
            {
                _logger.LogError($"Cannot found OrderDetails with id: {detailId}");
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
                ProductInOrder = new Product(),
                Order = new Order()
            };
        }

        public async Task<OrderDetail?> GetOrderDetailsWithChildAsync(int detailId)
        {
            var result = await _orderDetailRepository.GetOrderDetailAsync(detailId);
            if (result == null)
            {
                _logger.LogError($"Cannot found OrderDetails with id: {detailId}");
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

        public async Task UpdateDataAsync(int detailId, OrderDetail detail)
        {
            var result = await _orderDetailRepository.UpdateDetailDataAsync(detailId, new OrderDetailEntity()
            {
                Id = detail.Id,
                Discount = detail.Discount,
                OrderId = detail.OrderId,
                OrderNumber = detail.OrderNumber,
                Price = detail.Price,
                ProductId = detail.ProductId,
                Total = detail.Total
            });
            if (!result)
            {
                _logger.LogError("Cannot update Detail");
            }
        }

        public async Task UpdateOrderIdAsync(int detailId, int orderId)
        {
            var result = await _orderDetailRepository.UpdateDetailOrderIdAsync(detailId, orderId);
            if (!result)
            {
                _logger.LogError("Cannot update Detail");
            }
        }

        public async Task UpdateProductIdAsync(int detailId, int productId)
        {
            var result = await _orderDetailRepository.UpdateDetailProductIdAsync(detailId, productId);
            if (!result)
            {
                _logger.LogError("Cannot update Detail");
            }
        }

        public async Task UpdatePriceAsync(int detailId, float price)
        {
            var result = await _orderDetailRepository.UpdatePriceAsync(detailId, price);
            if (!result)
            {
                _logger.LogError("Cannot update Detail");
            }
        }

        public async Task UpdateDiscountAsync(int detailId, float discount)
        {
            var result = await _orderDetailRepository.UpdateDiscountAsync(detailId, discount);
            if (!result)
            {
                _logger.LogError("Cannot update Detail");
            }
        }

        public async Task UpdateTotalAsync(int detailId, float total)
        {
            var result = await _orderDetailRepository.UpdateTotalAsync(detailId, total);
            if (!result)
            {
                _logger.LogError("Cannot update Detail");
            }
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
