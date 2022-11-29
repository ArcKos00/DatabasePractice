using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface IProductService
    {
        public Task<int> AddProductAsync(string name, string discription, int supplierId, int categoryId, decimal unitPrice, float discount, IEnumerable<OrderDetail> inOrders);
        public Task<Product?> GetProductAsync(int id);
        public Task UpdateProductAsync(int id, Product newEntity);
        public Task DeleteProductAsync(int id);
        public Task<IEnumerable<Category>?> GetCategoryListAsync(Product product);
    }
}
