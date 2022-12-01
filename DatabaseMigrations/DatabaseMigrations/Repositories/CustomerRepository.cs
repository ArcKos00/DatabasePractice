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

        public async Task<int> AddCustomerAsync(CustomerEntity customer)
        {
            var entity = await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<int> AddCustomerAsync(string address, string email, string firstName, string secondName, string phone, string password, List<OrderEntity> orders)
        {
            var customer = await _dbContext.Customers.AddAsync(new CustomerEntity()
            {
                FirstName = firstName,
                LastName = secondName,
                Address1 = address,
                Phone = phone,
                Email = email,
                Password = password,
                DateEntered = DateOnly.FromDateTime(DateTime.Now)
            });

            await _dbContext.Orders.AddRangeAsync(orders.Select(s => new OrderEntity()
            {
                Id = s.Id,
                CustomerId = customer.Entity.Id,
                OrderNumber = s.OrderNumber,
                OrderDate = s.OrderDate,
                PaymentId = s.PaymentId,
                Paid = s.Paid,
                ShipperId = s.ShipperId,
                Shipper = s.Shipper,
                Customer = s.Customer,
                Details = s.Details,
                Pay = s.Pay
            }));

            await _dbContext.SaveChangesAsync();
            return customer.Entity.Id;
        }

        public async Task<CustomerEntity?> GetCustomerAsync(int customerId)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(f => f.Id == customerId);
        }

        public async Task<CustomerEntity?> GetCustomerWithChildAsync(int customerId)
        {
            return await _dbContext.Customers.Include(i => i.OrderList).FirstOrDefaultAsync(f => f.Id == customerId);
        }

        public async Task<List<OrderEntity>?> GetCustomerOrdersAsync(int customerId)
        {
            var customer = await _dbContext.Customers.Include(i => i.OrderList).FirstOrDefaultAsync(f => f.Id == customerId);

            return customer?.OrderList;
        }

        public async Task<bool> UpdateCustomerDataAsync(int entityId, CustomerEntity newEntity)
        {
            var entity = await GetCustomerAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerFNameAsync(int entityId, string fName)
        {
            var entity = await GetCustomerAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.FirstName = fName;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerPhoneAsync(int entityId, string phone)
        {
            var entity = await GetCustomerAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Phone = phone;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerEmailAsync(int entityId, string email)
        {
            var entity = await GetCustomerAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Email = email;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerLNameAsync(int entityId, string lName)
        {
            var entity = await GetCustomerAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.LastName = lName;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerAddressAsync(int entityId, string address)
        {
            var entity = await GetCustomerAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Address1 = address;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerPasswordAsync(int entityId, string password)
        {
            var entity = await GetCustomerAsync(entityId);
            if (entity == null)
            {
                return false;
            }

            entity.Password = password;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await GetCustomerAsync(customerId);
            if (customer == null)
            {
                return false;
            }

            _dbContext.Entry(customer).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
