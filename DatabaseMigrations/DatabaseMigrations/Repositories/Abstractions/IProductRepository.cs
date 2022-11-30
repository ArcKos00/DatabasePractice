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
        public Task<int> AddProductAsync(string name, string discription, float unitPrice, float discount, CategoryEntity category, SupplierEntity supplier, List<OrderDetailEntity> inOrders);
        public Task<ProductEntity?> GetProductByIdAsync(int id);
        public Task<bool> UpdateProductAsync(int id, ProductEntity payment);
        public Task<bool> DeleteProductAsync(int id);
        public Task<List<CategoryEntity>?> GetCategoryListAsync(ProductEntity product);
    }
}
