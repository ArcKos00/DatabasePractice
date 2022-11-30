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
    public class OrderService : BaseDataService<ApplicationDbContext>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<Order> _logger;
        public OrderService(
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            ILogger<Order> logger,
            IDbContextWrapper<ApplicationDbContext> wrapper,
            IOrderRepository repository)
            : base(wrapper, loggerService)
        {
            _orderRepository = repository;
            _logger = logger;
        }

        public async Task<int> AddOrderAsync(Customer customer, IEnumerable<OrderDetail> orderDetails, Shipper shipper, Payment pay, int orderNumber)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _orderRepository.AddOrderAsync(customer.Id, shipper.Id, pay.Id, orderNumber, orderDetails.Select(s => new OrderDetailEntity()
                {
                    OrderDetailId = s.Id,
                    OrderId = s.Order!.Id,
                    ProductId = s.ProductInOrder!.Id,
                    OrderNumber = s.OrderNumber,
                    Price = s.Price,
                    Discount = s.Discount,
                    Total = s.Total,
                }).ToList());
            });
        }

        public async Task<Order>? GetOrderASync(int id)
        {
            var result = await _orderRepository.GetOrderByIdAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found Order with id: {id}");
            }

            return new Order()
            {
                Id = result!.OrderId,
                CustomerId = result!.CustomerId,
                CustomerOrder = new Customer()
                {
                    FirstName = result.Customer!.FirstName,
                    LastName = result.Customer!.LastName,
                    Address1 = result.Customer!.Address1,
                    Phone = result.Customer!.Phone,
                    Email = result.Customer!.Email,
                    Password = result.Customer!.Password,
                    DateEntry = result.Customer!.DateEntered
                },
                OrderNumber = result!.OrderNumber,
                OrderDate = result!.OrderDate,
                PaymentId = result!.PaymentId,
                Payment = new Payment()
                {
                    Id = result!.PaymentId,
                    Allowed = result.Paid
                },
                Paid = result!.Paid,
                ShipperId = result!.ShipperId,
            };
        }

        public async Task UpdateOrder(int id, Order order)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderAsync(id, new OrderEntity()
                {
                    OrderId = order.Id,
                    CustomerId = order.CustomerOrder!.Id,
                    OrderNumber = order.OrderNumber,
                    OrderDate = order.OrderDate,
                    PaymentId = order.Payment!.Id,
                    Paid = order.Paid,
                    ShipperId = order.Shipper!.Id,
                });

                if (result == false)
                {
                    _logger.LogError($"Cannot update Order {id}");
                }
            });
        }
    }
}
