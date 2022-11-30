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
        public Task<int> AddCategotyAsync(string categoryName, string discription, IEnumerable<Product> products, bool isActive = false);

        public Task<Category> GetCategoryAsync(int categoryId);

        public Task UpdateCategoryAsync(int categoryId, Category category);

        public Task DeleteCategoryAsync(int id);
    }
}
