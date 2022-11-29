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

        public async Task<int> AddCustomerAsync(string firstName, string secondName, string phone, string password)
        {
            var customer = new CustomerEntity
            {
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

        public async Task<bool> DeleteCustomerByIdAsync(int customerId)
        {
            var customer = await GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return false;
            }

            _dbContext.Entry(customer).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerEntity?> GetCustomerByIdAsync(int customerId)
        {
            return await _dbContext.Customers.Include(i => i.OrderList).FirstOrDefaultAsync(f => f.CustomerId == customerId);
        }

        public async Task<List<OrderEntity>?> GetCustomerOrders(int customerId)
        {
            var customer = await _dbContext.Customers.Include(i => i.OrderList).FirstOrDefaultAsync(f => f.CustomerId == customerId);

            return customer!.OrderList;
        }

        public async Task<bool> UpdateCustomerByIdAsync(int entityId, CustomerEntity newEntity)
        {
            var entity = await GetCustomerByIdAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
