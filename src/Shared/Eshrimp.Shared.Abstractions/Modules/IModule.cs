using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Abstractions.Modules
{
    public interface IModule
    {
        string Name { get; }
        string Path { get; }
        void RegisterModule(IServiceCollection services);
        void UseModule(IApplicationBuilder app);
    }
}
