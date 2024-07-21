using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Eshrimp.Shared.Infrastructure.Services
{
    public class AppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AppInitializer> _logger;
        public AppInitializer(IServiceProvider serviceProvider,
            ILogger<AppInitializer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting App Initializer...");

            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(db => typeof(DbContext).IsAssignableFrom(db)
                && db != typeof(DbContext)
                && !db.IsInterface)
                .ToArray();

            var tasks = new List<Task>();

            using var scope = _serviceProvider.CreateScope();
            {
                foreach (var dbContextType in dbContextTypes)
                {
                    var dbContext = scope.ServiceProvider.GetService(dbContextType) as DbContext;
                    if (dbContext is null)
                    {
                        continue;
                    }

                    tasks.Add(dbContext.Database.MigrateAsync(cancellationToken));
                }
            }

            await Task.WhenAll(tasks);
            _logger.LogInformation("Finishing App Initializer");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
