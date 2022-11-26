using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;

namespace DatabaseMigrations.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task<string> AddPaymentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePaymentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentEntity?> GetPaymentByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePaymentAsync(string id, PaymentEntity payment)
        {
            throw new NotImplementedException();
        }
    }
}
