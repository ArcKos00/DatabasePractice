using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        public Task<string> AddCustomerAsync(string firstName, string lastName, string phone, string password);
        public Task<CustomerEntity?> GetCustomerByIdAsync(string customerId);
        public Task<bool> UpdateCustomerByIdAsync(string customerId, CustomerEntity newCustomerData);
        public Task<bool> DeleteCustomerByIdAsync(string customerId);
        public Task<IEnumerable<OrderEntity>?> GetCustomerOrders(string customerId);
    }
}
