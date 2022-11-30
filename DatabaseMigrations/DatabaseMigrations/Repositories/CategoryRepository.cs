using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(IDbContextWrapper<ApplicationDbContext> context)
        {
            _dbContext = context.DbContext;
        }

        public async Task<int> AddCategoryAsync(string categoryName, string discription, List<ProductEntity> products, bool isActive = false)
        {
            var category = await _dbContext.Categoryes.AddAsync(new CategoryEntity()
            {
                CategoryName = categoryName,
                Discription = discription,
                Active = isActive
            });

            await _dbContext.Products.AddRangeAsync(products.Select(s => new ProductEntity()
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                ProductDiscription = s.ProductDiscription,
                SupplierId = s.SupplierId,
                CategoryId = category.Entity.CategoryId,
                UnitPrice = s.UnitPrice,
                Discount = s.Discount,
                ProductAvailable = s.ProductAvailable,
                CurrentOrder = s.CurrentOrder,
                Details = s.Details,
                Supplier = s.Supplier,
                Category = s.Category
            }));

            await _dbContext.SaveChangesAsync();
            return category.Entity.CategoryId;
        }

        public async Task<bool> DeleteCategoryByIdAsync(int categoryId)
        {
            var category = await GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                return false;
            }

            _dbContext.Entry(category).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoryEntity?> GetCategoryByIdAsync(int categoryId)
        {
            return await _dbContext.Categoryes.Include(i => i.ProductsList).FirstOrDefaultAsync(f => f.CategoryId == categoryId);
        }

        public async Task<CategoryEntity?> GetCategoryByNameAsync(string categoryName)
        {
            return await _dbContext.Categoryes.Include(i => i.ProductsList).FirstOrDefaultAsync(f => f.CategoryName == categoryName);
        }

        public async Task<bool> UpdateCategoryByIdAsync(int entityId, CategoryEntity newEntity)
        {
            var entity = await GetCategoryByIdAsync(entityId);
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
