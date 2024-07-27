using Eshrimp.Bootstrapper;
using Eshrimp.Shared.Infrastructure;
using Eshrimp.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Host.ConfigureModules();
var assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var modules = ModuleLoader.LoadModules(assemblies);
services.AddInfrastructure(assemblies, modules);
services.RegisterModules(modules);


var app = builder.Build();
app.UseInfrastructure();
app.UseModules(modules);

app.MapGet("/", () => "Hello from Eshrimp Bootstrapper");
app.Run();
