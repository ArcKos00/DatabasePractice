using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using DatabaseMigrations.Models;
using DatabaseMigrations.Repositories;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services
{
    public class ShippersService : BaseDataService<ApplicationDbContext>, IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly ILogger<ShippersService> _logger;
        public ShippersService(
            IShipperRepository shipperRepository,
            ILogger<ShippersService> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _shipperRepository = shipperRepository;
            _logger = logger;
        }

        public async Task<int> AddShipperAsync(Shipper shipper)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _shipperRepository.AddShipperAsync(new ShipperEntity()
                {
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                });
            });
        }

        public async Task<int> AddShipperAsync(string name, string phone, IEnumerable<Order> orders)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _shipperRepository.AddShipperAsync(name, phone, orders.Select(s => new OrderEntity()
                {
                    Id = s.Id,
                    CustomerId = s.CustomerId,
                    OrderNumber = s.OrderNumber,
                    OrderDate = s.OrderDate,
                    PaymentId = s.PaymentId,
                    Paid = s.Paid,
                    ShipperId = s.ShipperId,
                }).ToList());
            });
        }

        public async Task<Shipper?> GetShipperAsync(int shipperId)
        {
            var result = await _shipperRepository.GetShipperAsync(shipperId);
            if (result == null)
            {
                _logger.LogError($"Cannot found shipper");
                return null!;
            }

            return new Shipper()
            {
                Id = result.Id,
                CompanyName = result.CompanyName,
                Phone = result.Phone
            };
        }

        public async Task<Shipper?> GetShipperWithChildAsync(int shipperId)
        {
            var result = await _shipperRepository.GetShipperAsync(shipperId);
            if (result == null)
            {
                _logger.LogError($"Cannot found shipper");
                return null!;
            }

            return new Shipper()
            {
                Id = result.Id,
                CompanyName = result.CompanyName,
                Phone = result.Phone,
                Order = result.OrderList.Select(s => new Order()
                {
                    Id = s.Id,
                    ShipperId = s.ShipperId,
                    CustomerId = s.CustomerId,
                    OrderDate = s.OrderDate,
                    OrderNumber = s.OrderNumber,
                    Paid = s.Paid,
                    PaymentId = s.PaymentId
                }).ToList()
            };
        }

        public async Task UpdateShipperDateAsync(int shipperId, Shipper newEntity)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _shipperRepository.UpdateShipperDataAsync(shipperId, new ShipperEntity()
                {
                    Id = newEntity.Id,
                    CompanyName = newEntity.CompanyName,
                    Phone = newEntity.Phone,
                });
                if (!result)
                {
                    _logger.LogError($"Cannot update ShipperData");
                }
            });
        }

        public async Task UpdateNameAsync(int shipperId, string name)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _shipperRepository.UpdateShipperNameAsync(shipperId, name);
                if (!result)
                {
                    _logger.LogError($"Cannot update ShipperData");
                }
            });
        }

        public async Task UpdatePhoneAsync(int shipperId, string phone)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _shipperRepository.UpdateShipperPhoneAsync(shipperId, phone);
                if (!result)
                {
                    _logger.LogError($"Cannot update ShipperData");
                }
            });
        }

        public async Task DeleteShipperAsync(int shipperId)
        {
            var result = await _shipperRepository.DeleteShipperAsync(shipperId);
            if (!result)
            {
                _logger.LogError($"Cannot delete ShipperData");
            }
        }
    }
}
