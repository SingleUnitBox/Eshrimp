using Eshrimp.Modules.Tanks.Api;
using Eshrimp.Modules.Tanks.Domain.Exceptions;
using Eshrimp.Shared.Abstractions.Exceptions;
using Eshrimp.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddTanks();

var app = builder.Build();

app.UseInfrastructure();
app.MapGet("/", () => "Hello from Eshrimp Bootstrapper");
app.Run();
