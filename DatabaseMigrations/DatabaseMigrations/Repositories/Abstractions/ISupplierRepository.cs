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
        public Task<string> AddSupplierAsync();
        public Task<SupplierEntity?> GetSupplierByIdAsync(string id);
        public Task<bool> UpdateSupplierAsync(string id, SupplierEntity payment);
        public Task<bool> DeleteSupplierAsync();
    }
}
