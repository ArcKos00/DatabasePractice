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
        public Task<int> AddPaymentAsync(string payType, List<OrderEntity> orders);
        public Task<PaymentEntity?> GetPaymentByIdAsync(int entityId);
        public Task<bool> UpdatePaymentAsync(int entityId, PaymentEntity payment);
        public Task<bool> DeletePaymentAsync(int entityId);
    }
}
