using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;
using DatabaseMigrations.Repositories;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services
{
    public class SupplierService : BaseDataService<ApplicationDbContext>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ILogger<Supplier> _logger;
        public SupplierService(
            ISupplierRepository supplierRepository,
            ILogger<Supplier> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _supplierRepository = supplierRepository;
            _logger = logger;
        }

        public async Task<int> AddSupplierAsync(string companyName, string contactFName, string phone, string email, IEnumerable<Product> products)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _supplierRepository.AddSupplierAsync(companyName, contactFName, phone, email, products.Select(s => new ProductEntity()
                {
                    ProductId = s.Id,
                    ProductName = s.ProductName,
                    ProductDiscription = s.ProductDescription,
                    SupplierId = s.Supplierid,
                    CategoryId = s.CategoryId,
                    UnitPrice = s.Price,
                    Discount = s.Discount,
                    ProductAvailable = s.Available,
                    CurrentOrder = s.CurrentOrder
                }).ToList());
            });
        }

        public async Task<Supplier?> GetSupplierAsync(int id)
        {
            var result = await _supplierRepository.GetSupplierByIdAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found Supplier id: {id}");
                return null!;
            }

            return new Supplier()
            {
                Id = result.SupplierId,
                CompanyName = result.CompanyName,
                ContactFName = result.ContactFName,
                Email = result.Email,
                Phone = result.Phone
            };
        }

        public async Task UpdateSupplierAsync(int id, Supplier newEntity)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.UpdateSupplierAsync(id, new SupplierEntity()
                {
                    SupplierId = newEntity.Id,
                    CompanyName = newEntity.CompanyName,
                    ContactFName = newEntity.ContactFName,
                    Phone = newEntity.Phone,
                    Email = newEntity.Email
                });
                if (result == false)
                {
                    _logger.LogError($"Cannot update this supplier");
                }
            });
        }

        public async Task DeleteSupplierAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.DeleteSupplierAsync(id);
                if (result == false)
                {
                    _logger.LogError($"Cannot update this supplier");
                }
            });
        }
    }
}
