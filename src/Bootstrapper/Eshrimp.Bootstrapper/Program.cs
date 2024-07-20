using Eshrimp.Modules.Tanks.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTanks();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.MapGet("/", () => "Hello from Eshrimp Bootstrapper");
app.Run();
