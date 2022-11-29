using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services
{
    public class ProductService : BaseDataService<ApplicationDbContext>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<Product> _logger;
        public ProductService(
            IProductRepository productRepository,
            ILogger<Product> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<int> AddProductAsync(string name, string discription, int supplierId, int categoryId, decimal unitPrice, float discount, IEnumerable<OrderDetail> inOrders)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _productRepository.AddProductAsync(name, discription, supplierId, categoryId, unitPrice, discount, inOrders.Select(s => new OrderDetailEntity()
                {
                    OrderDetailId = s.Id,
                    OrderId = s.Order!.Id,
                    ProductId = s.ProductInOrder!.Id,
                    OrderNumber = s.OrderNumber,
                    Price = s.Price,
                    Discount = s.Discount,
                    Total = s.Total,
                }).ToList());
            });
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            var result = await _productRepository.GetProductByIdAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found this Product");
                return null!;
            }

            return new Product()
            {
                Id = result.ProductId,
                ProductName = result.ProductName,
                CategoryId = result.CategoryId,
                Price = result.UnitPrice,
                Discount = result.Discount,
                Supplier = new Supplier()
                {
                    Id = result.SupplierId,
                    CompanyName = result.Supplier!.CompanyName,
                    Phone = result.Supplier.Phone
                }
            };
        }

        public async Task UpdateProductAsync(int id, Product newEntity)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductAsync(id, new ProductEntity()
                {
                    ProductId = newEntity.Id,
                    ProductName = newEntity.ProductName,
                    ProductDiscription = newEntity.ProductDescription,
                    SupplierId = newEntity.Supplier!.Id,
                    CategoryId = newEntity.Category!.Id,
                    UnitPrice = newEntity.Price,
                    Discount = newEntity.Discount,
                    ProductAvailable = newEntity.Available,
                    CurrentOrder = newEntity.CurrentOrder,
                });
                if (result == false)
                {
                    _logger.LogError($"Cannot Update this product id:{id}");
                }
            });
        }

        public async Task DeleteProductAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.DeleteProductAsync(id);
                if (result == false)
                {
                    _logger.LogError($"Cannot Update this product id:{id}");
                }
            });
        }

        public async Task<IEnumerable<Category>?> GetCategoryListAsync(Product product)
        {
            var result = await _productRepository.GetCategoryListAsync(new ProductEntity()
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
            });
            _logger.LogWarning("Nobody category is not exist this product");
            return result?.Select(s => new Category()
            {
                Id = s.CategoryId,
                CategoryName = s.CategoryName,
                Discription = s.Discription,
                Active = s.Active,
            }).ToList();
        }
    }
}
