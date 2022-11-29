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
        public Task<int> AddCustomerAsync(string firstName, string lastName, string phone, string password);
        public Task<CustomerEntity?> GetCustomerByIdAsync(int customerId);
        public Task<bool> UpdateCustomerByIdAsync(int customerId, CustomerEntity newCustomerData);
        public Task<bool> DeleteCustomerByIdAsync(int customerId);
        public Task<List<OrderEntity>?> GetCustomerOrders(int customerId);
    }
}
