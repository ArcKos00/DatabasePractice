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

        public async Task<int> AddShipperAsync(ShipperEntity shipper)
        {
            var entity = await _dbContext.Shippers.AddAsync(shipper);
            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
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
                Id = s.Id,
                CustomerId = s.CustomerId,
                OrderNumber = s.OrderNumber,
                OrderDate = s.OrderDate,
                Details = s.Details,
                PaymentId = s.PaymentId,
                Pay = s.Pay,
                Paid = s.Paid,
                ShipperId = entity.Entity.Id,
                Shipper = s.Shipper,
                Customer = s.Customer
            }));

            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<ShipperEntity?> GetShipperAsync(int entityId)
        {
            return await _dbContext.Shippers.FirstOrDefaultAsync(f => f.Id == entityId);
        }

        public async Task<List<OrderEntity>?> GetShipperOrdersAsync(int entityId)
        {
            var result = await _dbContext.Shippers.Include(i => i.OrderList).FirstOrDefaultAsync(f => f.Id == entityId);
            return result?.OrderList;
        }

        public async Task<bool> UpdateShipperDataAsync(int entityId, ShipperEntity newEntity)
        {
            var entity = await GetShipperAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateShipperNameAsync(int entityId, string companyName)
        {
            var entity = await GetShipperAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.CompanyName = companyName;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateShipperPhoneAsync(int entityId, string phone)
        {
            var entity = await GetShipperAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Phone = phone;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteShipperAsync(int entityId)
        {
            var entity = await GetShipperAsync(entityId);
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
