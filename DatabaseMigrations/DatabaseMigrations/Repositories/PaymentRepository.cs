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

        public async Task<int> AddPaymentAsync(string payType, List<OrderEntity> orders)
        {
            var entity = await _dbContext.Payments.AddAsync(new PaymentEntity()
            {
                PaymentType = payType,
                Allowed = true
            });

            await _dbContext.Orders.AddRangeAsync(orders.Select(s => new OrderEntity()
            {
                CustomerId = s.CustomerId,
                OrderNumber = s.OrderNumber,
                OrderDate = s.OrderDate,
                PaymentId = entity.Entity.PaymentId,
                ShipperId = s.ShipperId,
                Paid = entity.Entity.Allowed,
            }));

            await _dbContext.SaveChangesAsync();
            return entity.Entity.PaymentId;
        }

        public async Task<PaymentEntity?> GetPaymentByIdAsync(int entityId)
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(f => f.PaymentId == entityId);
        }

        public async Task<bool> DeletePaymentAsync(int entityId)
        {
            var entity = await GetPaymentByIdAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePaymentAsync(int entityId, PaymentEntity newEntity)
        {
            var entity = await GetPaymentByIdAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
