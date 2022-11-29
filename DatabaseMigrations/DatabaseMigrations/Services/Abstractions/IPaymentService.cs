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
        public Task<int> AddPaymentAsync(string payType, IEnumerable<Order> orders);
        public Task<Payment>? GetPaymentAsync(int id);
        public Task UpdatePaymentASync(int id, Payment payment);
        public Task DeletePaymentAsync(int id);
    }
}
