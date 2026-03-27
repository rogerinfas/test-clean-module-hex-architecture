using Auth.Module;
using Auth.Module.Infrastructure.Persistence;
using Inventory.Module;
using Inventory.Module.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var authConnectionString = builder.Configuration.GetConnectionString("AuthDb") 
    ?? "Host=localhost;Port=5432;Database=hexarchitecture;Username=acide;Password=123456";
var inventoryConnectionString = builder.Configuration.GetConnectionString("InventoryDb") 
    ?? "Host=localhost;Port=5432;Database=hexarchitecture;Username=acide;Password=123456";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthModule(authConnectionString);
builder.Services.AddInventoryModule(inventoryConnectionString);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var authDb = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    await authDb.Database.EnsureCreatedAsync();
    
    var inventoryDb = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
    inventoryDb.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
