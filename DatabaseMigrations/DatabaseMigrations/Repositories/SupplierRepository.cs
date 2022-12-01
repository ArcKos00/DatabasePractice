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

        public async Task<int> AddSupplierAsync(SupplierEntity supplier)
        {
            var entity = await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
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
                Id = s.Id,
                ProductName = s.ProductName,
                ProductDiscription = s.ProductDiscription,
                SupplierId = entity.Entity.Id,
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
            return entity.Entity.Id;
        }

        public async Task<SupplierEntity?> GetSupplierAsync(int supplierId)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(f => f.Id == supplierId);
        }

        public async Task<List<ProductEntity>?> GetSupplierProductList(int supplierId)
        {
            var entity = await _dbContext.Suppliers.Include(i => i.ProductList).FirstOrDefaultAsync(f => f.Id == supplierId);
            return entity?.ProductList;
        }

        public async Task<bool> UpdateSupplierDataAsync(int supplierId, SupplierEntity newEntity)
        {
            var entity = await GetSupplierAsync(supplierId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSupplierCompanyNameAsync(int supplierId, string name)
        {
            var entity = await GetSupplierAsync(supplierId);
            if (entity == null)
            {
                return false;
            }

            entity.CompanyName = name;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSupplierContactNameAsync(int supplierId, string contactName)
        {
            var entity = await GetSupplierAsync(supplierId);
            if (entity == null)
            {
                return false;
            }

            entity.ContactFName = contactName;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSupplierPhoneAsync(int supplierId, string phone)
        {
            var entity = await GetSupplierAsync(supplierId);
            if (entity == null)
            {
                return false;
            }

            entity.Phone = phone;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSupplierEmailAsync(int supplierId, string email)
        {
            var entity = await GetSupplierAsync(supplierId);
            if (entity == null)
            {
                return false;
            }

            entity.Email = email;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var entity = await GetSupplierAsync(supplierId);
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
