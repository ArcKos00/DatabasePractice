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
                return await _orderRepository.AddOrderAsync(
                    new CustomerEntity()
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Address1 = customer.Address1,
                        Phone = customer.Phone,
                        Email = customer.Email,
                        Password = customer.Password,
                        DateEntered = customer.DateEntry
                    },
                    new ShipperEntity()
                    {
                        Id = shipper.Id,
                        CompanyName = shipper.CompanyName,
                        Phone = shipper.Phone
                    },
                    new PaymentEntity()
                    {
                        Id = pay.Id,
                        PaymentType = pay.PaymentType,
                        Allowed = pay.Allowed
                    },
                    orderNumber,
                    orderDetails.Select(s => new OrderDetailEntity()
                    {
                        Id = s.Id,
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
            var result = await _orderRepository.GetOrderAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found Order with id: {id}");
                return null!;
            }
            else
            {
                return new Order()
                {
                    Id = result.Id,
                    CustomerId = result.CustomerId,
                    CustomerOrder = new Customer(),
                    OrderNumber = result!.OrderNumber,
                    OrderDate = result!.OrderDate,
                    PaymentId = result!.PaymentId,
                    Payment = new Payment(),
                    Paid = result!.Paid,
                    ShipperId = result!.ShipperId,
                };
            }
        }

        public async Task UpdateOrder(int id, Order order)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderDataAsync(id, new OrderEntity()
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    OrderNumber = order.OrderNumber,
                    OrderDate = order.OrderDate,
                    PaymentId = order.PaymentId,
                    Paid = order.Paid,
                    ShipperId = order.ShipperId,
                });

                if (!result)
                {
                    _logger.LogError($"Cannot update Order {id}");
                }
            });
        }
    }
}
