using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface IPaymentService
    {
        public Task<int> AddPaymentAsync(Payment payment);
        public Task<int> AddPaymentAsync(string payType, IEnumerable<Order> orders);
        public Task<Payment>? GetPaymentAsync(int paymentId);
        public Task UpdatePaymentDataAsync(int paymentId, Payment payment);
        public Task UpdatePaymentTypeAsync(int paymentId, string paymentType);
        public Task UpdateAllowAsync(int paymentId, bool paymentAllow);
        public Task DeletePaymentAsync(int paymentId);
    }
}
