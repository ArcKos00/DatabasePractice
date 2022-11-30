﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;

namespace DatabaseMigrations.Services.Abstractions
{
    public interface ICustomerService
    {
        public Task<int> AddCustomerAsync(string address, string email, string firstName, string secondName, string phone, string password, IEnumerable<Order> orders);
        public Task<Customer>? GetCustomerAsync(int id);
        public Task UpdateCustomerInfo(int id, Customer customer);
        public Task DeleteCustomer(int id);
    }
}