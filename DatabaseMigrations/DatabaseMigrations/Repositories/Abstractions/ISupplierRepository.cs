using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface ISupplierRepository
    {
        public Task<int> AddSupplierAsync(SupplierEntity supplier);
        public Task<int> AddSupplierAsync(string companyName, string contactFName, string phone, string email, List<ProductEntity> products);
        public Task<SupplierEntity?> GetSupplierAsync(int supplierId);
        public Task<List<ProductEntity>?> GetSupplierProductList(int supplierId);
        public Task<bool> UpdateSupplierDataAsync(int supplierId, SupplierEntity newEntity);
        public Task<bool> UpdateSupplierCompanyNameAsync(int supplierId, string name);
        public Task<bool> UpdateSupplierContactNameAsync(int supplierId, string contactName);
        public Task<bool> UpdateSupplierPhoneAsync(int supplierId, string phone);
        public Task<bool> UpdateSupplierEmailAsync(int supplierId, string email);
        public Task<bool> DeleteSupplierAsync(int supplierId);
    }
}
