using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface ISupplierService
    {
        public Task<int> AddSupplierAsync(Supplier supplier);
        public Task<int> AddSupplierAsync(string companyName, string contactFName, string phone, string email, IEnumerable<Product> products);
        public Task<Supplier?> GetSupplierAsync(int supplierId);
        public Task<List<Product>?> GetSupplierProductListAsync(int supplierId);
        public Task UpdateDataAsync(int supplierId, Supplier newEntity);
        public Task UpdateNameAsync(int supplierId, string newName);
        public Task UpdateContactNameAsync(int supplierId, string newName);
        public Task UpdatePhoneAsync(int supplierId, string newPhone);
        public Task UpdateEmailAsync(int supplierId, string newPhone);
        public Task DeleteSupplierAsync(int supplierId);
    }
}
