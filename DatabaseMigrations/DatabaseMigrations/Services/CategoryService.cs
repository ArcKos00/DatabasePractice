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

        public async Task<int> AddCategotyAsync(string categoryName, string discription, bool isActive = false)
        {
            var id = await _categoryRepository.AddCategoryAsync(categoryName, discription, isActive);
            _logger.LogInformation($"Created Category with id: {id}");
            return id;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            var result = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (result == null)
            {
                _logger.LogWarning($"Not found Category with id: {categoryId}");
                return null!;
            }

            return new Category()
            {
                Id = result.CategoryId,
                CategoryName = result.CategoryName,
                Active = result.Active,

                Products = result.ProductsList.Select(s => new Product()
                {
                    ProductName = s.ProductName,
                    CategoryId = s.CategoryId,
                    Price = s.UnitPrice,
                    Discount = s.Discount,
                    TheseSupplier = new Supplier()
                    {
                        CompanyName = s.Supplier?.CompanyName,
                        Phone = s.Supplier?.Phone
                    }
                })
            };
        }

        public async Task UpdateCategoryAsync(int categoryId, Category category)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.UpdateCategoryByIdAsync(categoryId, new CategoryEntity()
                {
                    CategoryId = categoryId,
                    CategoryName = category.CategoryName,
                    Active = category.Active,
                    Discription = category.Discription
                });
                if (result == false)
                {
                    _logger.LogWarning("Cannot Update this Category");
                }
            });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var result = await _categoryRepository.DeleteCategoryByIdAsync(id);
            if (result == false)
            {
                _logger.LogError($"Failed to delete Category with id: {id}");
            }
        }
    }
}
