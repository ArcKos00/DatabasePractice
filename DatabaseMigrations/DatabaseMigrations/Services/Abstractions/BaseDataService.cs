using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatabaseMigrations.Services.Abstractions
{
    public abstract class BaseDataService<T> : IBaseDataService
        where T : DbContext
    {
        private readonly IDbContextWrapper<T> _dbContextWrapper;
        private readonly ILogger<IBaseDataService> _logger;

        protected BaseDataService(IDbContextWrapper<T> dbContextWrapper, ILogger<IBaseDataService> logger)
        {
            _dbContextWrapper = dbContextWrapper;
            _logger = logger;
        }

        protected Task ExecuteSafeAsync(Func<Task> action, CancellationToken cancellToken = default) => ExecuteSafeAsync(token => action(), cancellToken);
        protected Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action, CancellationToken cancellToken = default) => ExecuteSafeAsync(tocken => action(), cancellToken);
        private async Task ExecuteSafeAsync(Func<CancellationToken, Task> action, CancellationToken cancellToken = default)
        {
            await using var transaction = await _dbContextWrapper.BeginTransactionAsync(cancellToken);

            try
            {
                await action(cancellToken);

                await transaction.CommitAsync(cancellToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellToken);
                _logger.LogError($"Failed to execute {ex}");
                throw;
            }
        }

        private async Task<TResult> ExecuteSafeAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellToken)
        {
            await using var transaction = await _dbContextWrapper.BeginTransactionAsync(cancellToken);

            try
            {
                var result = await action(cancellToken);
                await transaction.CommitAsync(cancellToken);

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellToken);
                _logger.LogError($"Failed to execute {ex}");
                throw;
            }
        }
    }
}
