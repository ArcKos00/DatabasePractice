using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrations.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(IDbContextWrapper<ApplicationDbContext> context)
        {
            _dbContext = context.DbContext;
        }

        public async Task<string> AddCustomerAsync(string firstName, string secondName, string phone, string password)
        {
            var customer = new CustomerEntity
            {
                CustomerId = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = secondName,
                Phone = phone,
                Password = password,
                DateEntered = DateTime.Now
            };

            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return customer.CustomerId;
        }

        public Task<bool> DeleteCustomerByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerEntity?> GetCustomerByIdAsync(string id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(f_or_d => f_or_d.CustomerId == id);
        }

        public Task<bool> UpdateCustomerByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
