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
        private readonly INotificationsService _notificationsService;
        private readonly ILogger<Customer> _logger;

        public CustomerService(
            ILogger<BaseDataService<ApplicationDbContext>> logService,
            ILogger<Customer> logger,
            ICustomerRepository repository,
            INotificationsService notification,
            IDbContextWrapper<ApplicationDbContext> wrapper)
            : base(wrapper, logService)
        {
            _customerRepository = repository;
            _notificationsService = notification;
            _logger = logger;
        }

        public async Task<int> AddCustomerAsync(string address, string email, string firstName, string secondName, string phone, string password)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                var result = await _customerRepository.AddCustomerAsync(address, email, firstName, secondName, phone, password);

                return result;
            });
        }

        public async Task<Customer>? GetCustomerAsync(int id)
        {
            var result = await _customerRepository.GetCustomerByIdAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found customer with id: {id}");
                return null!;
            }

            return new Customer()
            {
                Id = result.CustomerId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Address = result.Adddres,
                Email = result.Email,
                Phone = result.Phone,
                DateEntry = result.DateEntered,
                OrderList = result?.OrderList.Select(s => new Order()
                {
                    Id = s.OrderId,
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
                var result = await _customerRepository.UpdateCustomerByIdAsync(id, new CustomerEntity()
                {
                    CustomerId = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Adddres = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    Password = customer.Password,
                    DateEntered = customer.DateEntry
                });
                if (result == false)
                {
                    _logger.LogError($"Cannot Update this User {id}");
                }
            });
        }

        public async Task DeleteCustomer(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.DeleteCustomerByIdAsync(id);
                if (result == false)
                {
                    _logger.LogError($"Cannot Delete Customer with id: {id}");
                }
            });
        }
    }
}
