using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ShopManagement.AppServices;
using ShopManagement.Domain.Contracts;
using ShopManagement.Framework;
using ShopManagement.Infrastructures.Db;
using ShopManagement.Infrastructures.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsProduction())
{
}
ConfigurationManager configuration = builder.Configuration;


builder.Services.AddSingleton(configuration.GetSection("Settings").Get<SettingsModel>());


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


//builder.Services.AddScoped<ShopDbContext, ShopDbContext>();
string? connectionString = builder.Configuration.GetConnectionString("ShopDb");
builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductAppServices, ProductAppServices>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
