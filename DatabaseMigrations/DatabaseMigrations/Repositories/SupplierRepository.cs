using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SupplierRepository(IDbContextWrapper<ApplicationDbContext> wrapper)
        {
            _dbContext = wrapper.DbContext;
        }

        public async Task<int> AddSupplierAsync(string companyName, string contactFName, string phone, string email, List<ProductEntity> products)
        {
            var entity = await _dbContext.Suppliers.AddAsync(new SupplierEntity()
            {
                CompanyName = companyName,
                ContactFName = contactFName,
                Phone = phone,
                Email = email,
            });

            await _dbContext.Products.AddRangeAsync(products.Select(s => new ProductEntity()
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                ProductDiscription = s.ProductDiscription,
                SupplierId = entity.Entity.SupplierId,
                CategoryId = s.CategoryId,
                UnitPrice = s.UnitPrice,
                ProductAvailable = s.ProductAvailable,
                Discount = s.Discount,
                CurrentOrder = s.CurrentOrder,
                Details = s.Details,
                Category = s.Category,
                Supplier = s.Supplier
            }));

            await _dbContext.SaveChangesAsync();
            return entity.Entity.SupplierId;
        }

        public async Task<SupplierEntity?> GetSupplierByIdAsync(int entityId)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(f => f.SupplierId == entityId);
        }

        public async Task<bool> DeleteSupplierAsync(int entityId)
        {
            var entity = await GetSupplierByIdAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSupplierAsync(int entityId, SupplierEntity newEntity)
        {
            var entity = await GetSupplierByIdAsync(entityId);
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
