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

        public async Task<int> AddCategoryAsync(CategoryEntity category)
        {
            var entity = await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<int> AddCategoryAsync(string categoryName, string discription, List<ProductEntity> products, bool isActive = false)
        {
            var category = await _dbContext.Categories.AddAsync(new CategoryEntity()
            {
                CategoryName = categoryName,
                Discription = discription,
                Active = isActive
            });

            await _dbContext.Products.AddRangeAsync(products.Select(s => new ProductEntity()
            {
                Id = s.Id,
                ProductName = s.ProductName,
                ProductDiscription = s.ProductDiscription,
                SupplierId = s.SupplierId,
                CategoryId = category.Entity.Id,
                UnitPrice = s.UnitPrice,
                Discount = s.Discount,
                ProductAvailable = s.ProductAvailable,
                CurrentOrder = s.CurrentOrder,
                Details = s.Details,
                Supplier = s.Supplier,
                Category = s.Category
            }));

            await _dbContext.SaveChangesAsync();
            return category.Entity.Id;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(int categoryId)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(f => f.Id == categoryId);
        }

        public async Task<CategoryEntity?> GetCategoryByNameAsync(string categoryName)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(f => f.CategoryName == categoryName);
        }

        public async Task<CategoryEntity?> GetCategoryWithChildAsync(int categoryId)
        {
            return await _dbContext.Categories.Include(i => i.ProductsList).FirstOrDefaultAsync(f => f.Id == categoryId);
        }

        public async Task<CategoryEntity?> GetCategoryByNameWithChildAsync(string categoryName)
        {
            return await _dbContext.Categories.Include(i => i.ProductsList).FirstOrDefaultAsync(f => f.CategoryName == categoryName);
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await GetCategoryAsync(categoryId);
            if (category == null)
            {
                return false;
            }

            _dbContext.Entry(category).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryNameAsync(int entityId, string name)
        {
            var entity = await GetCategoryAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.CategoryName = name;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryDataAsync(int entityId, CategoryEntity newEntity)
        {
            var entity = await GetCategoryAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryActiveAsync(int entityId, bool active)
        {
            var entity = await GetCategoryAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Active = true;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryDiscriptionAsync(int entityId, string discription)
        {
            var entity = await GetCategoryAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Discription = discription;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
