using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public Task<string> AddProductAsync();
        public Task<ProductEntity?> GetProductByIdAsync(string id);
        public Task<bool> UpdateProductAsync(string id, ProductEntity payment);
        public Task<bool> DeleteProductAsync();
        public Task<List<CategoryEntity>> GetCategoryList(ProductEntity product);

    }
}
