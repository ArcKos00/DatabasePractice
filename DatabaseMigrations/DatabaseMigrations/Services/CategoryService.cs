using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services
{
    public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<Category> _logger;

        public CategoryService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICategoryRepository categoryRepository,
            ILogger<Category> loggerService)
            : base(dbContextWrapper, logger)
        {
            _categoryRepository = categoryRepository;
            _logger = loggerService;
        }

        public async Task<int> AddCategotyAsync(Category category)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _categoryRepository.AddCategoryAsync(
                    new CategoryEntity()
                    {
                        Active = category.Active,
                        CategoryName = category.CategoryName,
                        Discription = category.Discription
                    });
            });
        }

        public async Task<int> AddCategotyAsync(string categoryName, string discription, IEnumerable<Product> products, bool isActive = false)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _categoryRepository.AddCategoryAsync(
                    categoryName,
                    discription,
                    products.Select(s => new ProductEntity()
                    {
                        Id = s.Id,
                        ProductName = s.ProductName,
                        ProductDiscription = s.ProductDescription,
                        SupplierId = s.Supplierid,
                        CategoryId = s.CategoryId,
                        UnitPrice = s.Price,
                        Discount = s.Discount,
                        ProductAvailable = s.Available,
                        CurrentOrder = s.CurrentOrder,
                    })
                    .ToList(),
                    isActive);
            });
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            var result = await _categoryRepository.GetCategoryAsync(categoryId);
            if (result == null)
            {
                _logger.LogWarning($"Not found Category with id: {categoryId}");
                return null!;
            }

            return new Category()
            {
                Id = result.Id,
                CategoryName = result.CategoryName,
                Active = result.Active,
                Discription = result.Discription,
                Products = result.ProductsList.Select(s => new Product())
            };
        }

        public async Task<Category> GetCategoryByNameAsync(string categoryName)
        {
            var result = await _categoryRepository.GetCategoryByNameAsync(categoryName);
            if (result == null)
            {
                _logger.LogWarning($"Not found Category \"{categoryName}\"");
                return null!;
            }

            return new Category()
            {
                Id = result.Id,
                CategoryName = result.CategoryName,
                Active = result.Active,
                Discription = result.Discription,
                Products = result.ProductsList.Select(s => new Product())
            };
        }

        public async Task<Category> GetCategoryWithChildAsync(int categoryId)
        {
            var result = await _categoryRepository.GetCategoryAsync(categoryId);
            if (result == null)
            {
                _logger.LogWarning($"Not found Category with id: {categoryId}");
                return null!;
            }

            return new Category()
            {
                Id = result.Id,
                CategoryName = result.CategoryName,
                Active = result.Active,
                Discription = result.Discription,
                Products = result.ProductsList.Select(s => new Product()
                {
                    Id = s.Id,
                    CategoryId = s.CategoryId,
                    Supplierid = s.SupplierId,
                    Available = s.ProductAvailable,
                    CurrentOrder = s.CurrentOrder,
                    Discount = s.Discount,
                    Price = s.UnitPrice,
                    ProductDescription = s.ProductDiscription,
                    ProductName = s.ProductName
                })
            };
        }

        public async Task<Category> GetCategoryByNameWithChildAsync(string categoryName)
        {
            var result = await _categoryRepository.GetCategoryByNameWithChildAsync(categoryName);
            if (result == null)
            {
                _logger.LogWarning($"Not found Category with id: {categoryName}");
                return null!;
            }

            return new Category()
            {
                Id = result.Id,
                CategoryName = result.CategoryName,
                Active = result.Active,
                Discription = result.Discription,
                Products = result.ProductsList.Select(s => new Product()
                {
                    Id = s.Id,
                    CategoryId = s.CategoryId,
                    Supplierid = s.SupplierId,
                    Available = s.ProductAvailable,
                    CurrentOrder = s.CurrentOrder,
                    Discount = s.Discount,
                    Price = s.UnitPrice,
                    ProductDescription = s.ProductDiscription,
                    ProductName = s.ProductName
                })
            };
        }

        public async Task UpdateCategoryDateAsync(int categoryId, Category category)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.UpdateCategoryDataAsync(categoryId, new CategoryEntity()
                {
                    Id = categoryId,
                    CategoryName = category.CategoryName,
                    Active = category.Active,
                    Discription = category.Discription
                });
                if (!result)
                {
                    _logger.LogWarning("Cannot Update this Category");
                }
            });
        }

        public async Task UpdateCategoryNameAsync(int categoryId, string newName)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.UpdateCategoryNameAsync(categoryId, newName);
                if (!result)
                {
                    _logger.LogError("Cannot update category");
                }
            });
        }

        public async Task UpdateCategoryDiscriptionAsync(int categoryId, string discription)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.UpdateCategoryDiscriptionAsync(categoryId, discription);
                if (!result)
                {
                    _logger.LogError("Cannot update category");
                }
            });
        }

        public async Task UpdateCategoryActiveAsync(int categoryId, bool active)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.UpdateCategoryActiveAsync(categoryId, active);
                if (!result)
                {
                    _logger.LogError("Cannot update category");
                }
            });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.DeleteCategoryAsync(id);
                if (!result)
                {
                    _logger.LogError($"Failed to delete Category with id: {id}");
                }
            });
        }
    }
}
