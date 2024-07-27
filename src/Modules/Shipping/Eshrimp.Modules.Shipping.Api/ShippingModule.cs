using Eshrimp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Modules.Shipping.Api
{
    public class ShippingModule : IModule
    {
        public const string BasePath = "shipping-module";
        public string Name => "Shipping";

        public string Path => BasePath;

        public void RegisterModule(IServiceCollection services)
        {
            
        }

        public void UseModule(IApplicationBuilder app)
        {
            
        }
    }
}
