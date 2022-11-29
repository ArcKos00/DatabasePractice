using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services
{
    public class PaymentService : BaseDataService<ApplicationDbContext>, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<Payment> _logger;
        public PaymentService(
            IPaymentRepository paymentRepository,
            ILogger<Payment> logger,
            ILogger<BaseDataService<ApplicationDbContext>> loggerService,
            IDbContextWrapper<ApplicationDbContext> wrapper)
        : base(wrapper, loggerService)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }
    }
}
