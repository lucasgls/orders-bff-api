using Microsoft.EntityFrameworkCore;
using OrderProcessingAPI.Application.Interfaces;
using OrderProcessingAPI.Application.Mappers;
using OrderProcessingAPI.Application.Services;
using OrderProcessingAPI.Infrastructure.Data;
using OrderProcessingAPI.Infrastructure.Repositories;
using OrderProcessingAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null)
    throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();