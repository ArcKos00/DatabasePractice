using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        public Task<string> AddCategoryAsync(string categoryName, string discription, bool isActive = false);
        public Task<CategoryEntity?> GetCategoryByIdAsync(string categoryId);
        public Task<CategoryEntity?> GetCategoryByNameAsync(string categoryName);
        public Task<bool> UpdateCategoryByIdAsync(string categoryId, CategoryEntity newCategory);
        public Task<bool> DeleteCategoryByIdAsync(string categoryId);
    }
}
