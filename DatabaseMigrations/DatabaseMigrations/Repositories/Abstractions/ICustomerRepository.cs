using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        public Task<string> AddCustomerAsync(string firstName, string lastName, string phone, string password);
        public Task<CustomerEntity?> GetCustomerByIdAsync(string id);
        public Task<bool> UpdateCustomerByIdAsync();
        public Task<bool> DeleteCustomerByIdAsync();
    }
}
