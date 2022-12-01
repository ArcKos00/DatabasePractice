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

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            var result = await _customerRepository.AddCustomerAsync(new CustomerEntity()
            {
                Address1 = customer.Address1,
                DateEntered = customer.DateEntry,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Password = customer.Password,
                Phone = customer.Phone
            });
            return result;
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

        public async Task<Customer?> GetCustomerAsync(int customerId)
        {
            var result = await _customerRepository.GetCustomerAsync(customerId);
            if (result == null)
            {
                _logger.LogError($"Cannot found customer with id: {customerId}");
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
                DateEntry = result.DateEntered
            };
        }

        public async Task<Customer?> GetCustomerWithChildAsync(int customerId)
        {
            var result = await _customerRepository.GetCustomerAsync(customerId);
            if (result == null)
            {
                _logger.LogError($"Cannot found customer with id: {customerId}");
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
                    ShipperId = s.ShipperId,
                    CustomerId = s.CustomerId,
                    PaymentId = s.PaymentId
                }),
            };
        }

        public async Task<List<Order>?> GetCustomerOrdersAsync(int customerId)
        {
            var result = await _customerRepository.GetCustomerOrdersAsync(customerId);
            if (result == null)
            {
                _logger.LogError("Cannot getted orderList");
                return null!;
            }

            return result.Select(s => new Order()
            {
                Id = s.Id,
                ShipperId = s.ShipperId,
                CustomerId = s.CustomerId,
                OrderDate = s.OrderDate,
                OrderNumber = s.OrderNumber,
                Paid = s.Paid,
                PaymentId = s.PaymentId
            }).ToList();
        }

        public async Task UpdateCustomerDataAsync(int customerId, Customer customer)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerDataAsync(customerId, new CustomerEntity()
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
                    _logger.LogError($"Cannot Update this User {customerId}");
                }
            });
        }

        public async Task UpdateCustomerFNameAsync(int customerId, string newName)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerFNameAsync(customerId, newName);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this User {customerId}");
                }
            });
        }

        public async Task UpdateCustomerLNameAsync(int customerId, string newLastName)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerLNameAsync(customerId, newLastName);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this User {customerId}");
                }
            });
        }

        public async Task UpdateCustomerAddressAsync(int customerId, string newAddres)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerAddressAsync(customerId, newAddres);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this User {customerId}");
                }
            });
        }

        public async Task UpdateCustomerPhoneAsync(int customerId, string newPhone)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerPhoneAsync(customerId, newPhone);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this User {customerId}");
                }
            });
        }

        public async Task UpdateCustomerEmailAsync(int customerId, string newEmail)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerEmailAsync(customerId, newEmail);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this User {customerId}");
                }
            });
        }

        public async Task UpdateCustomerPasswordAsync(int customerId, string newPassword)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerPasswordAsync(customerId, newPassword);
                if (!result)
                {
                    _logger.LogError($"Cannot Update this User {customerId}");
                }
            });
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.DeleteCustomerAsync(customerId);
                if (!result)
                {
                    _logger.LogError($"Cannot Delete Customer with id: {customerId}");
                }
            });
        }
    }
}
