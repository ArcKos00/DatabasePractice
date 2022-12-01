using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        public Task<int> AddCategoryAsync(CategoryEntity category);
        public Task<int> AddCategoryAsync(string categoryName, string discription, List<ProductEntity> products, bool isActive = false);
        public Task<CategoryEntity?> GetCategoryAsync(int categoryId);
        public Task<CategoryEntity?> GetCategoryWithChildAsync(int categoryId);
        public Task<CategoryEntity?> GetCategoryByNameAsync(string categoryName);
        public Task<CategoryEntity?> GetCategoryByNameWithChildAsync(string categoryName);
        public Task<bool> DeleteCategoryAsync(int categoryId);
        public Task<bool> UpdateCategoryDataAsync(int categoryId, CategoryEntity newCategory);
        public Task<bool> UpdateCategoryActiveAsync(int categoryId, bool active);
        public Task<bool> UpdateCategoryDiscriptionAsync(int categoryId, string discription);
        public Task<bool> UpdateCategoryNameAsync(int categoryId, string name);
    }
}
