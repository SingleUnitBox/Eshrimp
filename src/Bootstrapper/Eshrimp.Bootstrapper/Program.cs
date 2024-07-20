var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.MapGet("/", () => "Hello from Eshrimp Bootstrapper");
app.Run();
