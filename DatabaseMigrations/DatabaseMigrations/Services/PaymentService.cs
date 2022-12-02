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
        private readonly ILogger<PaymentService> _logger;
        public PaymentService(
            IPaymentRepository paymentRepository,
            ILogger<PaymentService> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        public async Task<int> AddPaymentAsync(Payment payment)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _paymentRepository.AddPaymentAsync(new PaymentEntity()
                {
                    Id = payment.Id,
                    Allowed = payment.Allowed,
                    PaymentType = payment.PaymentType
                });
            });
        }

        public async Task<int> AddPaymentAsync(string payType, IEnumerable<Order> orders)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _paymentRepository.AddPaymentAsync(payType, orders.Select(s => new OrderEntity()
                {
                    Id = s.Id,
                    CustomerId = s.CustomerOrder.Id,
                    OrderNumber = s.OrderNumber,
                    OrderDate = s.OrderDate,
                    PaymentId = s.Payment.Id,
                    Paid = s.Paid,
                    ShipperId = s.Shipper!.Id
                }).ToList());
            });
        }

        public async Task<Payment?> GetPaymentAsync(int paymentId)
        {
            var result = await _paymentRepository.GetPaymentAsync(paymentId);
            if (result == null)
            {
                _logger.LogError($"Cannot found payment no{paymentId}");
                return null!;
            }

            return new Payment()
            {
                Id = result.Id,
                PaymentType = result.PaymentType,
                Allowed = result.Allowed
            };
        }

        public async Task UpdatePaymentDataAsync(int paymentId, Payment payment)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.UpdatePaymentDataAsync(paymentId, new PaymentEntity()
                {
                    Id = payment.Id,
                    PaymentType = payment.PaymentType,
                    Allowed = payment!.Allowed,
                    OrderList = payment.Orders!.Select(s => new OrderEntity()
                    {
                        Id = s.Id,
                        CustomerId = s.CustomerOrder!.Id,
                        OrderNumber = s.OrderNumber,
                        OrderDate = s.OrderDate,
                        PaymentId = s.PaymentId,
                        Paid = s.Paid,
                        ShipperId = s.ShipperId,
                    }).ToList()
                });
                if (!result)
                {
                    _logger.LogWarning("Cannot update");
                }
            });
        }

        public async Task UpdatePaymentTypeAsync(int paymentId, string type)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.UpdatePaymentPaymentTypeAsync(paymentId, type);
                if (!result)
                {
                    _logger.LogWarning("Cannot update");
                }
            });
        }

        public async Task UpdateAllowAsync(int paymentId, bool allow)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.UpdatePaymentAllowAsync(paymentId, allow);
                if (!result)
                {
                    _logger.LogWarning("Cannot update");
                }
            });
        }

        public async Task DeletePaymentAsync(int paymentId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _paymentRepository.DeletePaymentAsync(paymentId);
                if (!result)
                {
                    _logger.LogError($"Cannot delete this payment");
                }
            });
        }
    }
}