using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PaymentRepository(IDbContextWrapper<ApplicationDbContext> wrapper)
        {
            _dbContext = wrapper.DbContext;
        }

        public async Task<int> AddPaymentAsync(PaymentEntity payment)
        {
            var entity = await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<int> AddPaymentAsync(string payType, List<OrderEntity> orders)
        {
            var entity = await _dbContext.Payments.AddAsync(new PaymentEntity()
            {
                PaymentType = payType,
                Allowed = true
            });

            await _dbContext.Orders.AddRangeAsync(orders.Select(s => new OrderEntity()
            {
                Id = s.Id,
                CustomerId = s.CustomerId,
                OrderNumber = s.OrderNumber,
                OrderDate = s.OrderDate,
                PaymentId = entity.Entity.Id,
                ShipperId = s.ShipperId,
                Paid = entity.Entity.Allowed,
                Shipper = s.Shipper,
                Customer = s.Customer,
                Details = s.Details,
                Pay = s.Pay
            }));

            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<PaymentEntity?> GetPaymentAsync(int entityId)
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(f => f.Id == entityId);
        }

        public async Task<bool> UpdatePaymentDataAsync(int entityId, PaymentEntity newEntity)
        {
            var entity = await GetPaymentAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePaymentPaymentTypeAsync(int entityId, string paymentType)
        {
            var entity = await GetPaymentAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.PaymentType = paymentType;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePaymentAllowAsync(int entityId, bool allow)
        {
            var entity = await GetPaymentAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Allowed = allow;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePaymentAsync(int entityId)
        {
            var entity = await GetPaymentAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
