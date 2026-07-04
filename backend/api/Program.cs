using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.API.Application.Interfaces;
using SalesOrderManagement.API.Application.Mappings;
using SalesOrderManagement.API.Application.Services;
using SalesOrderManagement.API.Infrastructure.Data;
using SalesOrderManagement.API.Infrastructure.Interfaces;
using SalesOrderManagement.API.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("DefaultConnection is not configured.");

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ISalesOrderService, SalesOrderService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowReactClient");

app.UseAuthorization();

app.MapControllers();

app.Run();