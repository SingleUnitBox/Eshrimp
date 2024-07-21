using Eshrimp.Shared.Abstractions.Modules;
using Eshrimp.Modules.Tanks.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Modules.Tanks.Api
{
    public class TanksModule : IModule
    {
        public const string BasePath = "tanks-module";
        public string Name => "Tanks";

        public string Path => BasePath;

        public void RegisterModule(IServiceCollection services)
        {
            services.AddInfrastructure();
        }

        public void UseModule(IApplicationBuilder app)
        {
            
        }
    }
}
