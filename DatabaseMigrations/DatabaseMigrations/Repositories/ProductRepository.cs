using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(IDbContextWrapper<ApplicationDbContext> wrapper)
        {
            _dbContext = wrapper.DbContext;
        }

        public async Task<int> AddProductAsync(ProductEntity product)
        {
            var entity = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<int> AddProductAsync(string name, string discription, float unitPrice, float discount, CategoryEntity category, SupplierEntity supplier, List<OrderDetailEntity> inOrders)
        {
            var entity = await _dbContext.Products.AddAsync(new ProductEntity()
            {
                ProductName = name,
                ProductDiscription = discription,
                Supplier = supplier,
                SupplierId = supplier.Id,
                Category = category,
                CategoryId = category.Id,
                UnitPrice = unitPrice,
                Discount = discount,
            });

            await _dbContext.OrderDetails.AddRangeAsync(inOrders.Select(s => new OrderDetailEntity()
            {
                OrderId = s.OrderId,
                ProductId = entity.Entity.Id,
                Price = entity.Entity.UnitPrice,
                Discount = entity.Entity.Discount,
                Total = s.Total,
                Id = s.Id,
                OrderNumber = s.OrderNumber,
                Order = s.Order,
                Product = s.Product
            }));

            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<ProductEntity?> GetProductAsync(int productId)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == productId);
        }

        public async Task<ProductEntity?> GetProductWithChildAsync(int productId)
        {
            return await _dbContext.Products.Include(i => i.Supplier).Include(i => i.Category).Include(i => i.Details).FirstOrDefaultAsync(f => f.Id == productId);
        }

        public async Task<List<CategoryEntity>?> GetCategoryListAsync(ProductEntity newEntity)
        {
            return await _dbContext.Categories.Where(s => s.ProductsList.Contains(newEntity)).ToListAsync();
        }

        public async Task<bool> UpdateProductDataAsync(int entityId, ProductEntity newEntity)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductNameAsync(int entityId, string productName)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.ProductName = productName;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductDiscriptionAsync(int entityId, string discription)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.ProductDiscription = discription;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductSupplierIdAsync(int entityId, int supplierId)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.SupplierId = supplierId;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductCategoryIdAsync(int entityId, int categoryId)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.CategoryId = categoryId;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductPriceAsync(int entityId, float price)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.UnitPrice = price;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductDiscountAsync(int entityId, float discount)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Discount = discount;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductAvailableAsync(int entityId, bool available)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.ProductAvailable = available;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductOrderIdAsync(int entityId, int orderId)
        {
            var entity = await GetProductAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.CurrentOrder = orderId;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int entityId)
        {
            var entity = await GetProductAsync(entityId);
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
