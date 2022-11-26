using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IPaymentRepository
    {
        public Task<string> AddPaymentAsync();
        public Task<PaymentEntity?> GetPaymentByIdAsync(string id);
        public Task<bool> UpdatePaymentAsync(string id, PaymentEntity payment);
        public Task<bool> DeletePaymentAsync();
    }
}
