using Eshrimp.Modules.Tanks.Api;
using Eshrimp.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddTanks(builder.Configuration);

var app = builder.Build();

app.UseInfrastructure();
app.MapGet("/", () => "Hello from Eshrimp Bootstrapper");
app.Run();
