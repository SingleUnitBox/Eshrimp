using Eshrimp.Modules.Tanks.Application;
using Eshrimp.Modules.Tanks.Domain;
using Eshrimp.Modules.Tanks.Infrastructure;
using Eshrimp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Modules.Tanks.Api
{
    internal class TanksModule : IModule
    {
        public const string BasePath = "tanks-module";
        public string Name => "Tanks";
        public string Path => BasePath;

        public void RegisterModule(IServiceCollection services)
        {
            services.AddDomain();
            services.AddApplication();
            services.AddInfrastructure();
        }

        public void UseModule(IApplicationBuilder app)
        {
            
        }
    }
}
