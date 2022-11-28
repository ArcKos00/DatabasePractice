using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;

namespace DatabaseMigrations.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<string> AddProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity?> GetProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(string id, ProductEntity payment)
        {
            throw new NotImplementedException();
        }

        // получить список категорий в которых находится продукт
        public async Task<List<CategoryEntity>> GetCategoryListAsync(ProductEntity product)
        {
        }
    }
}
