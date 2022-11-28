using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services
{
    public class NotificationService : INotificationsService
    {
        private readonly ILogger<NotificationService> _loggerService;
        public NotificationService(ILogger<NotificationService> logger)
        {
            _loggerService = logger;
        }

        public void Notification(NotifyType type, string message)
        {
            _loggerService.LogInformation($"{type}, {message}");
        }
    }
}
