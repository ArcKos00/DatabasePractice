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
        private readonly ILogger<ProductService> _logger;
        public ProductService(
            IProductRepository productRepository,
            ILogger<ProductService> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _productRepository.AddProductAsync(new ProductEntity()
                {
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    Discount = product.Discount,
                    ProductAvailable = product.Available,
                    ProductDiscription = product.ProductDescription,
                    ProductName = product.ProductName,
                    UnitPrice = product.Price
                });
            });
        }

        public async Task<int> AddProductAsync(string name, string discription, Supplier supplier, Category category, float unitPrice, float discount, IEnumerable<OrderDetail> inOrders)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _productRepository.AddProductAsync(
                    name,
                    discription,
                    unitPrice,
                    discount,
                    new CategoryEntity()
                    {
                        Id = category.Id,
                        CategoryName = category.CategoryName,
                        Discription = category.Discription,
                        Active = category.Active
                    },
                    new SupplierEntity()
                    {
                        Id = supplier.Id,
                        CompanyName = supplier.CompanyName,
                        ContactFName = supplier.ContactFName,
                        Phone = supplier.Phone,
                        Email = supplier.Email
                    },
                    inOrders.Select(s => new OrderDetailEntity()
                    {
                        Id = s.Id,
                        OrderId = s.Order.Id,
                        ProductId = s.ProductInOrder.Id,
                        OrderNumber = s.OrderNumber,
                        Price = s.Price,
                        Discount = s.Discount,
                        Total = s.Total,
                    }).ToList());
            });
        }

        public async Task<Product?> GetProductAsync(int productId)
        {
            var result = await _productRepository.GetProductAsync(productId);
            if (result == null)
            {
                _logger.LogError($"Cannot found this Product");
                return null!;
            }

            return new Product()
            {
                Id = result.Id,
                ProductName = result.ProductName,
                CategoryId = result.CategoryId,
                Price = result.UnitPrice,
                Discount = result.Discount,
                Supplier = new Supplier()
            };
        }

        public async Task<Product?> GetProductWithChild(int productId)
        {
            var result = await _productRepository.GetProductAsync(productId);
            if (result == null)
            {
                _logger.LogError($"Cannot found this Product");
                return null!;
            }

            return new Product()
            {
                Id = result.Id,
                ProductName = result.ProductName,
                CategoryId = result.CategoryId,
                Price = result.UnitPrice,
                Discount = result.Discount,
                Supplier = new Supplier()
                {
                    Id = result.SupplierId,
                    CompanyName = result.Supplier.CompanyName,
                    Phone = result.Supplier.Phone
                }
            };
        }

        public async Task UpdateDataAsync(int productId, Product newEntity)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductDataAsync(productId, new ProductEntity()
                {
                    Id = newEntity.Id,
                    ProductName = newEntity.ProductName,
                    ProductDiscription = newEntity.ProductDescription,
                    SupplierId = newEntity.SupplierId,
                    CategoryId = newEntity.CategoryId,
                    UnitPrice = newEntity.Price,
                    Discount = newEntity.Discount,
                    ProductAvailable = newEntity.Available,
                    CurrentOrder = newEntity.CurrentOrder,
                });
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task UpdateNameAsync(int productId, string name)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductNameAsync(productId, name);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task UpdateDiscriptionAsync(int productId, string discription)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductDiscriptionAsync(productId, discription);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task UpdateSupplierIdAsync(int productId, int supplierId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductSupplierIdAsync(productId, supplierId);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task UpdateCategoryIdAsync(int productId, int categoryId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductCategoryIdAsync(productId, categoryId);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task UpdatePriceAsync(int productId, float price)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductPriceAsync(productId, price);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task UpdateDiscountAsync(int productId, float discount)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductDiscountAsync(productId, discount);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task UpdateAvailableAsync(int productId, bool available)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductAvailableAsync(productId, available);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task UpdateOredrIdAsync(int productId, int orderId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductOrderIdAsync(productId, orderId);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task DeleteProductAsync(int productId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.DeleteProductAsync(productId);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this product id:{productId}");
                }
            });
        }

        public async Task<IEnumerable<Category>?> GetCategoryListAsync(Product product)
        {
            var result = await _productRepository.GetCategoryListAsync(new ProductEntity()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
            });
            _logger.LogWarning("Nobody category is not exist this product");
            return result?.Select(s => new Category()
            {
                Id = s.Id,
                CategoryName = s.CategoryName,
                Discription = s.Discription,
                Active = s.Active,
            }).ToList();
        }

        public async Task<IEnumerable<Category>?> GetCategoryListAsync(int id)
        {
            var product = await GetProductAsync(id);
            if (product == null)
            {
                return new List<Category>();
            }

            return await GetCategoryListAsync(product);
        }
    }
}
