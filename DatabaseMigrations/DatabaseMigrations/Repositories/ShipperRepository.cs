using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ShipperRepository(IDbContextWrapper<ApplicationDbContext> wrapper)
        {
            _dbContext = wrapper.DbContext;
        }

        public async Task<int> AddShipperAsync(string name, string phone, List<OrderEntity> orders)
        {
            var entity = await _dbContext.Shippers.AddAsync(new ShipperEntity()
            {
                CompanyName = name,
                Phone = phone
            });

            await _dbContext.Orders.AddRangeAsync(orders.Select(s => new OrderEntity()
            {
                OrderId = s.OrderId,
                CustomerId = s.CustomerId,
                OrderNumber = s.OrderNumber,
                OrderDate = s.OrderDate,
                Details = s.Details,
                PaymentId = s.PaymentId,
                Pay = s.Pay,
                Paid = s.Paid,
                ShipperId = entity.Entity.ShipperId,
                Shipper = s.Shipper,
                Customer = s.Customer
            }));

            await _dbContext.SaveChangesAsync();
            return entity.Entity.ShipperId;
        }

        public async Task<ShipperEntity?> GetShipperByIdAsync(int entityId)
        {
            return await _dbContext.Shippers.FirstOrDefaultAsync(f => f.ShipperId == entityId);
        }

        public async Task<bool> DeleteShipperAsync(int entityId)
        {
            var entity = await GetShipperByIdAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateShipperAsync(int entityId, ShipperEntity newEntity)
        {
            var entity = await GetShipperByIdAsync(entityId);
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
