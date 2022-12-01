using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        public Task<int> AddCustomerAsync(CustomerEntity customer);
        public Task<int> AddCustomerAsync(string address, string email, string firstName, string secondName, string phone, string password, List<OrderEntity> orders);
        public Task<CustomerEntity?> GetCustomerAsync(int customerId);
        public Task<CustomerEntity?> GetCustomerWithChildAsync(int customerId);
        public Task<List<OrderEntity>?> GetCustomerOrdersAsync(int customerId);
        public Task<bool> UpdateCustomerDataAsync(int entityId, CustomerEntity newEntity);
        public Task<bool> UpdateCustomerFNameAsync(int entityId, string fName);
        public Task<bool> UpdateCustomerLNameAsync(int entityId, string lName);
        public Task<bool> UpdateCustomerAddressAsync(int entityId, string address);
        public Task<bool> UpdateCustomerPhoneAsync(int entityId, string phone);
        public Task<bool> UpdateCustomerEmailAsync(int entityId, string email);
        public Task<bool> UpdateCustomerPasswordAsync(int entityId, string password);
        public Task<bool> DeleteCustomerAsync(int customerId);
    }
}
