using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
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

        public async Task<int> AddProductAsync(string name, string discription, int supplierId, int categoryId, decimal unitPrice, float discount, List<OrderDetailEntity> inOrders)
        {
            var entity = await _dbContext.Products.AddAsync(new ProductEntity()
            {
                ProductName = name,
                ProductDiscription = discription,
                SupplierId = supplierId,
                CategoryId = categoryId,
                UnitPrice = unitPrice,
                Discount = discount,
            });

            await _dbContext.OrderDetails.AddRangeAsync(inOrders.Select(s => new OrderDetailEntity()
            {
                OrderId = s.OrderId,
                ProductId = entity.Entity.ProductId,
                Price = entity.Entity.UnitPrice,
                Discount = entity.Entity.Discount,
                Total = s.Total,
            }));

            await _dbContext.SaveChangesAsync();
            return entity.Entity.ProductId;
        }

        public async Task<ProductEntity?> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(f => f.ProductId == id);
        }

        public async Task<bool> DeleteProductAsync(int entityId)
        {
            var entity = await GetProductByIdAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductAsync(int entityId, ProductEntity newEntity)
        {
            var entity = await GetProductByIdAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryEntity>?> GetCategoryListAsync(ProductEntity newEntity)
        {
            return await _dbContext.Categoryes.Where(s => s.ProductsList.Contains(newEntity)).ToListAsync();
        }
    }
}
