using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public Task<int> AddProductAsync(ProductEntity product);
        public Task<int> AddProductAsync(string name, string discription, float unitPrice, float discount, CategoryEntity category, SupplierEntity supplier, List<OrderDetailEntity> inOrders);
        public Task<ProductEntity?> GetProductAsync(int productId);
        public Task<List<CategoryEntity>?> GetCategoryListAsync(ProductEntity newEntity);
        public Task<bool> UpdateProductDataAsync(int entityId, ProductEntity newEntity);
        public Task<bool> UpdateProductNameAsync(int entityId, string productName);
        public Task<bool> UpdateProductDiscriptionAsync(int entityId, string discription);
        public Task<bool> UpdateProductSupplierIdAsync(int entityId, int supplierId);
        public Task<bool> UpdateProductCategoryIdAsync(int entityId, int categoryId);
        public Task<bool> UpdateProductPriceAsync(int entityId, float price);
        public Task<bool> UpdateProductDiscountAsync(int entityId, float discount);
        public Task<bool> UpdateProductAvailableAsync(int entityId, bool available);
        public Task<bool> DeleteProductAsync(int entityId);
    }
}
