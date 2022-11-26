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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(IDbContextWrapper<ApplicationDbContext> context)
        {
            _dbContext = context.DbContext;
        }

        public async Task<string> AddCategoryAsync(string categoryName, string discription, bool isActive = false)
        {
            var category = new CategoryEntity()
            {
                CategoryId = Guid.NewGuid().ToString(),
                CategoryName = categoryName,
                Discription = discription,
                Active = isActive
            };

            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category.CategoryId;
        }

        public Task<bool> DeleteCategoryByIdAsync(string categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryEntity?> GetCategoryByIdAsync(string id)
        {
            return await _dbContext.Categoryes.FirstOrDefaultAsync(f_or_d => f_or_d.CategoryId == id);
        }

        public Task<CategoryEntity?> GetCategoryByNameAsync(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryByIdAsync(string categoryId, CategoryEntity newCategory)
        {
            throw new NotImplementedException();
        }
    }
}
