using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<int> AddCategotyAsync(Category category);
        public Task<int> AddCategotyAsync(string categoryName, string discription, IEnumerable<Product> products, bool isActive = false);
        public Task<Category> GetCategoryAsync(int categoryId);
        public Task<Category> GetCategoryByNameAsync(string categoryName);
        public Task<Category> GetCategoryWithChildAsync(int categoryId);
        public Task<Category> GetCategoryByNameWithChildAsync(string categoryName);
        public Task UpdateCategoryDateAsync(int categoryId, Category category);
        public Task UpdateCategoryNameAsync(int categoryId, string newName);
        public Task UpdateCategoryDiscriptionAsync(int categoryId, string discription);
        public Task UpdateCategoryActiveAsync(int categoryId, bool active);
        public Task DeleteCategoryAsync(int categoryId);
    }
}
