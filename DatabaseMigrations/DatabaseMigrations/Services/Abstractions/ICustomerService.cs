using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface ICustomerService
    {
        public Task<int> AddCustomerAsync(Customer customer);
        public Task<int> AddCustomerAsync(string address, string email, string firstName, string secondName, string phone, string password, IEnumerable<Order> orders);
        public Task<Customer?> GetCustomerAsync(int customerId);
        public Task<Customer?> GetCustomerWithChildAsync(int customerId);
        public Task<List<Order>?> GetCustomerOrdersAsync(int customerId);
        public Task UpdateCustomerDataAsync(int entityId, Customer newEntity);
        public Task UpdateCustomerFNameAsync(int entityId, string fName);
        public Task UpdateCustomerLNameAsync(int entityId, string lName);
        public Task UpdateCustomerAddressAsync(int entityId, string address);
        public Task UpdateCustomerPhoneAsync(int entityId, string phone);
        public Task UpdateCustomerEmailAsync(int entityId, string email);
        public Task UpdateCustomerPasswordAsync(int entityId, string password);
        public Task DeleteCustomerAsync(int customerId);
    }
}