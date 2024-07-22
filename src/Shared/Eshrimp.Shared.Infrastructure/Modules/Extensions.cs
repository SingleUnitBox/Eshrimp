using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Eshrimp.Shared.Infrastructure.Modules
{
    internal static class Extensions
    {
        public static IHostBuilder ConfigureModules(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration((ctx, cfg) =>
            {
                foreach (var settings in GetSettings("*"))
                {
                    cfg.AddJsonFile(settings);
                }

                foreach (var setting in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
                {
                    cfg.AddJsonFile(setting);
                }

                IEnumerable<string> GetSettings(string pattern) =>
                    Directory.EnumerateFiles(
                        ctx.HostingEnvironment.ContentRootPath, $"module.{pattern}.json", SearchOption.AllDirectories);
            });

            return hostBuilder;
        }
    }
}
