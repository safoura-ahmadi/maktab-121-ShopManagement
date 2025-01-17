using Microsoft.EntityFrameworkCore;
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

//string universityName = configuration.GetSection("Settings:ApplicationName").Value;
//Settings? settings = configuration.GetSection("SettingsModel").Get<Settings>();


builder.Services.AddSingleton(configuration.GetSection("Settings").Get<SettingsModel>());


// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();


//builder.Services.AddScoped<ShopDbContext, ShopDbContext>();
string? connectionString = builder.Configuration.GetConnectionString("ShopDb");
builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductAppServices, ProductAppServices>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Erfan"))
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
