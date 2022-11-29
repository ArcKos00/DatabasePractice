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
    public class PaymentService : BaseDataService<ApplicationDbContext>, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<Payment> _logger;
        public PaymentService(
            IPaymentRepository paymentRepository,
            ILogger<Payment> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        public async Task<int> AddPaymentAsync(string payType, IEnumerable<Order> orders)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _paymentRepository.AddPaymentAsync(payType, orders.Select(s => new OrderEntity()
                {
                    OrderId = s.Id,
                    CustomerId = s.CustomerOrder!.Id,
                    OrderNumber = s.OrderNumber,
                    OrderDate = s.OrderDate,
                    PaymentId = s.Payment!.Id,
                    Paid = s.Paid,
                    ShipperId = s.Shipper!.Id,
                }).ToList());
            });
        }

        public async Task<Payment>? GetPaymentAsync(int id)
        {
            var result = await _paymentRepository.GetPaymentByIdAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found payment no{id}");
                return null!;
            }

            return new Payment()
            {
                Id = result.PaymentId,
                PaymentType = result.PaymentType,
                Allowed = result.Allowed
            };
        }

        public async Task UpdatePaymentASync(int id, Payment payment)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.UpdatePaymentAsync(id, new PaymentEntity()
                {
                    PaymentId = payment.Id,
                    OrderList = payment.Orders!.Select(s => new OrderEntity()
                    {
                        OrderId = s.Id,
                        CustomerId = s.CustomerOrder!.Id,
                        OrderNumber = s.OrderNumber,
                        OrderDate = s.OrderDate,
                        PaymentId = s.Payment!.Id,
                        Paid = s.Paid,
                        ShipperId = s.Shipper!.Id,
                    }).ToList(),
                    PaymentType = payment.PaymentType,
                    Allowed = payment!.Allowed
                });
            });
        }

        public async Task DeletePaymentAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.DeletePaymentAsync(id);
                if (result == false)
                {
                    _logger.LogError($"Cannot delete this payment");
                }
            });
        }
    }
}
