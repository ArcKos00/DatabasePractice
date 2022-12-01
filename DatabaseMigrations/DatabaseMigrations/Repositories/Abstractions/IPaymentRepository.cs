using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IPaymentRepository
    {
        public Task<int> AddPaymentAsync(PaymentEntity payment);
        public Task<int> AddPaymentAsync(string payType, List<OrderEntity> orders);
        public Task<PaymentEntity?> GetPaymentAsync(int entityId);
        public Task<bool> UpdatePaymentDataAsync(int entityId, PaymentEntity newEntity);
        public Task<bool> UpdatePaymentPaymentTypeAsync(int entityId, string paymentType);
        public Task<bool> UpdatePaymentAllowerAsync(int entityId, bool allow);
        public Task<bool> DeletePaymentAsync(int entityId);
    }
}
