using Eshrimp.Bootstrapper;
using Eshrimp.Modules.Tanks.Api;
using Eshrimp.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddInfrastructure();
var assemblies = ModuleLoader.LoadAssemblies();
var modules = ModuleLoader.LoadModules(assemblies);
services.RegisterModules(modules);


var app = builder.Build();
app.UseInfrastructure();
foreach (var module in modules)
{
    module.UseModule(app);
}

app.MapGet("/", () => "Hello from Eshrimp Bootstrapper");
app.Run();
