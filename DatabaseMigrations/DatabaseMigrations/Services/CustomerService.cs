using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services
{
    public class CustomerService : BaseDataService<ApplicationDbContext>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<Customer> _logger;

        public CustomerService(
            ILogger<BaseDataService<ApplicationDbContext>> logService,
            ILogger<Customer> logger,
            ICustomerRepository repository,
            IDbContextWrapper<ApplicationDbContext> wrapper)
            : base(wrapper, logService)
        {
            _customerRepository = repository;
            _logger = logger;
        }

        public async Task<int> AddCustomerAsync(string address, string email, string firstName, string secondName, string phone, string password, IEnumerable<Order> orders)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _customerRepository.AddCustomerAsync(address, email, firstName, secondName, phone, password, orders.Select(s => new OrderEntity()
                {
                    Id = s.Id,
                    CustomerId = s.CustomerId,
                    OrderNumber = s.OrderNumber,
                    OrderDate = s.OrderDate,
                    PaymentId = s.PaymentId,
                    Paid = s.Paid,
                    ShipperId = s.ShipperId
                }).ToList());
            });
        }

        public async Task<Customer>? GetCustomerAsync(int id)
        {
            var result = await _customerRepository.GetCustomerAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found customer with id: {id}");
                return null!;
            }

            return new Customer()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Address1 = result.Address1,
                Email = result.Email,
                Phone = result.Phone,
                DateEntry = result.DateEntered,
                OrderList = result.OrderList.Select(s => new Order()
                {
                    Id = s.Id,
                    OrderNumber = s.OrderNumber,
                    OrderDate = s.OrderDate,
                    Paid = s.Paid,
                }),
            };
        }

        public async Task UpdateCustomerInfo(int id, Customer customer)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerDataAsync(id, new CustomerEntity()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address1 = customer.Address1,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    Password = customer.Password,
                    DateEntered = customer.DateEntry
                });
                if (!result)
                {
                    _logger.LogError($"Cannot Update this User {id}");
                }
            });
        }

        public async Task DeleteCustomer(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.DeleteCustomerAsync(id);
                if (!result)
                {
                    _logger.LogError($"Cannot Delete Customer with id: {id}");
                }
            });
        }
    }
}
