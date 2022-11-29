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
        private readonly ILogger<Shipper> _logger;
        public ShippersService(
            IShipperRepository shipperRepository,
            ILogger<Shipper> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _shipperRepository = shipperRepository;
            _logger = logger;
        }

        public async Task<int> AddShipperAsync(string name, string phone, IEnumerable<Order> orders)
        {
            return await ExecuteSafeAsync<int>(async () =>
            {
                return await _shipperRepository.AddShipperAsync(name, phone, orders.Select(s => new OrderEntity()
                {
                    OrderId = s.Id,
                    CustomerId = s.CustomerId,
                    OrderNumber = s.OrderNumber,
                    OrderDate = s.OrderDate,
                    PaymentId = s.PaymentId,
                    Paid = s.Paid,
                    ShipperId = s.ShipperId,
                }).ToList());
            });
        }

        public async Task<Shipper?> GetShipperByIdAsync(int id)
        {
            var result = await _shipperRepository.GetShipperByIdAsync(id);
            if (result == null)
            {
                _logger.LogError($"Cannot found shipper");
                return null!;
            }

            return new Shipper()
            {
                Id = result.ShipperId,
                CompanyName = result.CompanyName,
                Phone = result.Phone
            };
        }

        public async Task UpdateShipperAsync(int id, Shipper newEntity)
        {
            await ExecuteSafeAsync(async () =>
            {
                var result = await _shipperRepository.UpdateShipperAsync(id, new ShipperEntity()
                {
                    ShipperId = newEntity.Id,
                    CompanyName = newEntity.CompanyName,
                    Phone = newEntity.Phone,
                });
                if (result == false)
                {
                    _logger.LogError($"Cannot update ShipperData");
                }
            });
        }

        public async Task DeleteShipperAsync(int id)
        {
            var result = await _shipperRepository.DeleteShipperAsync(id);
            if (result == false)
            {
                _logger.LogError($"Cannot delete ShipperData");
            }
        }
    }
}
