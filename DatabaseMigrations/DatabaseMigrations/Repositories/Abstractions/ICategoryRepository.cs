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
        public Task<int> AddCategoryAsync(string categoryName, string discription, List<ProductEntity> products, bool isActive = false);
        public Task<CategoryEntity?> GetCategoryByIdAsync(int categoryId);
        public Task<CategoryEntity?> GetCategoryByNameAsync(string categoryName);
        public Task<bool> UpdateCategoryByIdAsync(int categoryId, CategoryEntity newCategory);
        public Task<bool> DeleteCategoryByIdAsync(int categoryId);
    }
}
