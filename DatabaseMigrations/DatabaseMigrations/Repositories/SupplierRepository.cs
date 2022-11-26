using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;

namespace DatabaseMigrations.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public Task<string> AddSupplierAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSupplierAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SupplierEntity?> GetSupplierByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSupplierAsync(string id, SupplierEntity payment)
        {
            throw new NotImplementedException();
        }
    }
}
