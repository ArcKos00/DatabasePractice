using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface ISupplierRepository
    {
        public Task<int> AddSupplierAsync(string companyName, string contactFName, string phone, string email, List<ProductEntity> products);
        public Task<SupplierEntity?> GetSupplierByIdAsync(int id);
        public Task<bool> UpdateSupplierAsync(int id, SupplierEntity payment);
        public Task<bool> DeleteSupplierAsync(int id);
    }
}
