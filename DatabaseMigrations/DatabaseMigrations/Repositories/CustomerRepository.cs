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

        public async Task<bool> DeleteCustomerByIdAsync(string customerId)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(f => f.CustomerId == customerId);
            if (customer == null)
            {
                return false;
            }

            _dbContext.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerEntity?> GetCustomerByIdAsync(string customerId)
        {
            return await _dbContext.Customers.Include(i => i.OrderList).FirstOrDefaultAsync(f => f.CustomerId == customerId);
        }

        public async Task<IEnumerable<OrderEntity>?> GetCustomerOrders(string customerId)
        {
            var customer = await _dbContext.Customers.Include(i => i.OrderList).FirstOrDefaultAsync(f => f.CustomerId == customerId);

            return customer?.OrderList;
        }

        public async Task<bool> UpdateCustomerByIdAsync(string customerId, CustomerEntity newCustomerData)
        {
            var customer = await _dbContext.Customers.Include(i => i.OrderList).FirstOrDefaultAsync(f => f.CustomerId == customerId);
            if (customer == null)
            {
                return false;
            }

            _dbContext.Customers.Update(UpdateCustomer(customer, newCustomerData));
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private CustomerEntity UpdateCustomer(CustomerEntity oldData, CustomerEntity newData)
        {
            oldData.FirstName = newData?.FirstName;
            oldData.LastName = newData?.LastName;
            oldData.Address1 = newData?.Address1;
            oldData.Phone = newData?.Phone;
            oldData.Email = newData?.Email;
            oldData.Password = newData?.Password;

            return oldData;
        }
    }
}
