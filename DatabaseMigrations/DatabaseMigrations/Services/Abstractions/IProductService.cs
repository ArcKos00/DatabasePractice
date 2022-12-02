using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface IProductService
    {
        public Task<int> AddProductAsync(Product product);
        public Task<int> AddProductAsync(string name, string discription, Supplier supplier, Category category, float unitPrice, float discount, IEnumerable<OrderDetail> inOrders);
        public Task<Product?> GetProductAsync(int productId);
        public Task<Product?> GetProductWithChild(int productId);
        public Task UpdateDataAsync(int productId, Product newEntity);
        public Task UpdateNameAsync(int productId, string newName);
        public Task UpdateDiscriptionAsync(int productId, string newDiscription);
        public Task UpdateSupplierIdAsync(int productId, int newId);
        public Task UpdateCategoryIdAsync(int productId, int newId);
        public Task UpdatePriceAsync(int productId, float newPrice);
        public Task UpdateDiscountAsync(int productId, float discount);
        public Task UpdateAvailableAsync(int productId, bool available);
        public Task UpdateOredrIdAsync(int productId, int orderId);
        public Task DeleteProductAsync(int productId);
        public Task<IEnumerable<Category>?> GetCategoryListAsync(Product product);
        public Task<IEnumerable<Category>?> GetCategoryListAsync(int categoryId);
    }
}
