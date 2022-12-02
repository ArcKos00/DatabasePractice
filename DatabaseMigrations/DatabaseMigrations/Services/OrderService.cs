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
        private readonly ILogger<OrderService> _logger;
        public OrderService(
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            ILogger<OrderService> logger,
            IDbContextWrapper<ApplicationDbContext> wrapper,
            IOrderRepository repository)
            : base(wrapper, loggerService)
        {
            _orderRepository = repository;
            _logger = logger;
        }

        public async Task<int> AddOrderAsync(Order order)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _orderRepository.AddOrderAsync(new OrderEntity()
                {
                    Id = order.Id,
                    ShipperId = order.ShipperId,
                    CustomerId = order.CustomerId,
                    OrderDate = order.OrderDate,
                    OrderNumber = order.OrderNumber,
                    Paid = order.Paid,
                    PaymentId = order.PaymentId
                });
            });
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
                        OrderId = s.OrderId,
                        ProductId = s.ProductId,
                        OrderNumber = s.OrderNumber,
                        Price = s.Price,
                        Discount = s.Discount,
                        Total = s.Total,
                    }).ToList());
            });
        }

        public async Task<Order?> GetOrderAsync(int orderId)
        {
            var result = await _orderRepository.GetOrderAsync(orderId);
            if (result == null)
            {
                _logger.LogError($"Cannot found Order with id: {orderId}");
                return null!;
            }

            return new Order()
            {
                Id = result.Id,
                CustomerId = result.CustomerId,
                OrderNumber = result.OrderNumber,
                OrderDate = result.OrderDate,
                PaymentId = result.PaymentId,
                Paid = result.Paid,
                ShipperId = result.ShipperId,
            };
        }

        public async Task<Order?> GetOrderWithChildAsync(int orderId)
        {
            var result = await _orderRepository.GetOrderWithDetailsAsync(orderId);
            if (result == null ||
                result.Customer == null ||
                result.Details == null ||
                result.Shipper == null ||
                result.Pay == null)
            {
                _logger.LogError($"Cannot found Order with id: {orderId}");
                return null!;
            }

            return new Order()
            {
                Id = result.Id,
                CustomerId = result.CustomerId,
                OrderNumber = result.OrderNumber,
                OrderDate = result.OrderDate,
                PaymentId = result.PaymentId,
                Paid = result.Paid,
                ShipperId = result.ShipperId,
                Shipper = new Shipper()
                {
                    Id = result.ShipperId,
                    CompanyName = result.Shipper.CompanyName,
                    Phone = result.Shipper.Phone
                },
                CustomerOrder = new Customer()
                {
                    Id = result.CustomerId,
                    Address1 = result.Customer.Address1,
                    DateEntry = result.OrderDate,
                    Email = result.Customer.Email,
                    FirstName = result.Customer.FirstName,
                    LastName = result.Customer.LastName,
                    Password = result.Customer.Password,
                    Phone = result.Customer.Phone
                },
                Details = result.Details.Select(s => new OrderDetail()
                {
                    Id = s.Id,
                    Discount = s.Discount,
                    OrderId = s.OrderId,
                    OrderNumber = s.OrderNumber,
                    Price = s.Price,
                    ProductId = s.ProductId,
                    Total = s.Total
                }),
                Payment = new Payment()
                {
                    Id = result.PaymentId,
                    Allowed = result.Pay.Allowed,
                    PaymentType = result.Pay.PaymentType
                }
            };
        }

        public async Task UpdateOrderDataAsync(int orderId, Order order)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderDataAsync(orderId, new OrderEntity()
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
                    _logger.LogError($"Cannot update Order {orderId}");
                }
            });
        }

        public async Task UpdateCustomerIdAsync(int orderId, int customerId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderCustomerIdAsync(orderId, customerId);

                if (!result)
                {
                    _logger.LogError($"Cannot update Order {orderId}");
                }
            });
        }

        public async Task UpdateOrderNumberAsync(int orderId, int orderomber)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderOrderNumberAsync(orderId, orderomber);

                if (!result)
                {
                    _logger.LogError($"Cannot update Order {orderId}");
                }
            });
        }

        public async Task UpdateOrderDateAsync(int orderId, DateOnly date)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderOrderDateAsync(orderId, date);

                if (!result)
                {
                    _logger.LogError($"Cannot update Order {orderId}");
                }
            });
        }

        public async Task UpdatePaymentIdAsync(int orderId, int paymentId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderPaymentIdAsync(orderId, paymentId);

                if (!result)
                {
                    _logger.LogError($"Cannot update Order {orderId}");
                }
            });
        }

        public async Task UpdatePaidAsync(int orderId, bool paid)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderPaidAsync(orderId, paid);

                if (!result)
                {
                    _logger.LogError($"Cannot update Order {orderId}");
                }
            });
        }

        public async Task UpdateShipperIdAsync(int orderId, int shipperId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderCustomerIdAsync(orderId, shipperId);

                if (!result)
                {
                    _logger.LogError($"Cannot update Order {orderId}");
                }
            });
        }

        public async Task DeleteOrderAsycn(int orderId)
        {
            var result = await _orderRepository.DeleteOrder(orderId);
            if (!result)
            {
                _logger.LogError("Cannot delete order");
            }
        }
    }
}
