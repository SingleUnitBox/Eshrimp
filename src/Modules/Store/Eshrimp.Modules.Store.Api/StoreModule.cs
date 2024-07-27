using Eshrimp.Modules.Store.Application;
using Eshrimp.Modules.Store.Domain;
using Eshrimp.Modules.Store.Infrastructure;
using Eshrimp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Modules.Store.Api
{
    internal class StoreModule : IModule
    {
        public const string BasePath = "store-module";
        public string Name => "Store";
        public string Path => BasePath;

        public void RegisterModule(IServiceCollection services)
        {
            services.AddDomain();
            services.AddApplication();
            services.AddInfrastructure();
        }

        public void UseModule(IApplicationBuilder app)
        {
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("stores", () => "hello from stores");
            //});
        }
    }
}
