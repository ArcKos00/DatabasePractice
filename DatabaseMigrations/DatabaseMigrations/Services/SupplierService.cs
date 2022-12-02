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
    public class SupplierService : BaseDataService<ApplicationDbContext>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ILogger<SupplierService> _logger;
        public SupplierService(
            ISupplierRepository supplierRepository,
            ILogger<SupplierService> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _supplierRepository = supplierRepository;
            _logger = logger;
        }

        public async Task<int> AddSupplierAsync(Supplier supplier)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _supplierRepository.AddSupplierAsync(new SupplierEntity()
                {
                    Id = supplier.Id,
                    CompanyName = supplier.CompanyName,
                    ContactFName = supplier.ContactFName,
                    Email = supplier.Email,
                    Phone = supplier.Phone
                });
            });
        }

        public async Task<int> AddSupplierAsync(string companyName, string contactFName, string phone, string email, IEnumerable<Product> products)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _supplierRepository.AddSupplierAsync(companyName, contactFName, phone, email, products.Select(s => new ProductEntity()
                {
                    Id = s.Id,
                    ProductName = s.ProductName,
                    ProductDiscription = s.ProductDescription,
                    SupplierId = s.SupplierId,
                    CategoryId = s.CategoryId,
                    UnitPrice = s.Price,
                    Discount = s.Discount,
                    ProductAvailable = s.Available,
                    CurrentOrder = s.CurrentOrder
                }).ToList());
            });
        }

        public async Task<Supplier?> GetSupplierAsync(int supplierId)
        {
            var result = await _supplierRepository.GetSupplierAsync(supplierId);
            if (result == null)
            {
                _logger.LogError($"Cannot found Supplier id: {supplierId}");
                return null!;
            }

            return new Supplier()
            {
                Id = result.Id,
                CompanyName = result.CompanyName,
                ContactFName = result.ContactFName,
                Email = result.Email,
                Phone = result.Phone
            };
        }

        public async Task<List<Product>?> GetSupplierProductListAsync(int supplierId)
        {
            var result = await _supplierRepository.GetSupplierProductList(supplierId);
            if (result == null)
            {
                _logger.LogError($"Cannot found Supplier id: {supplierId}");
                return null!;
            }

            return result.Select(s => new Product()
            {
                Id = s.Id,
                ProductName = s.ProductName,
                SupplierId = s.SupplierId,
                Available = s.ProductAvailable,
                CurrentOrder = s.CurrentOrder,
                CategoryId = s.CategoryId,
                Discount = s.Discount,
                Price = s.UnitPrice,
                ProductDescription = s.ProductDiscription
            }).ToList();
        }

        public async Task UpdateDataAsync(int supplierId, Supplier newEntity)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.UpdateSupplierDataAsync(supplierId, new SupplierEntity()
                {
                    Id = newEntity.Id,
                    CompanyName = newEntity.CompanyName,
                    ContactFName = newEntity.ContactFName,
                    Phone = newEntity.Phone,
                    Email = newEntity.Email
                });
                if (!result)
                {
                    _logger.LogError($"Cannot update this supplier");
                }
            });
        }

        public async Task UpdateNameAsync(int supplierId, string name)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.UpdateSupplierCompanyNameAsync(supplierId, name);
                if (!result)
                {
                    _logger.LogError($"Cannot update this supplier");
                }
            });
        }

        public async Task UpdateContactNameAsync(int supplierId, string contactName)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.UpdateSupplierContactNameAsync(supplierId, contactName);
                if (!result)
                {
                    _logger.LogError($"Cannot update this supplier");
                }
            });
        }

        public async Task UpdatePhoneAsync(int supplierId, string phone)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.UpdateSupplierPhoneAsync(supplierId, phone);
                if (!result)
                {
                    _logger.LogError($"Cannot update this supplier");
                }
            });
        }

        public async Task UpdateEmailAsync(int supplierId, string email)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.UpdateSupplierEmailAsync(supplierId, email);
                if (!result)
                {
                    _logger.LogError($"Cannot update this supplier");
                }
            });
        }

        public async Task DeleteSupplierAsync(int supplierId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.DeleteSupplierAsync(supplierId);
                if (!result)
                {
                    _logger.LogError($"Cannot update this supplier");
                }
            });
        }
    }
}
