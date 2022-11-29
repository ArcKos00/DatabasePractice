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
        public Task<int> AddSupplierAsync(string companyName, string contactFName, string phone, string email, IEnumerable<Product> products);
        public Task<Supplier?> GetSupplierAsync(int id);
        public Task UpdateSupplierAsync(int id, Supplier newEntity);
        public Task DeleteSupplierAsync(int id);
    }
}
