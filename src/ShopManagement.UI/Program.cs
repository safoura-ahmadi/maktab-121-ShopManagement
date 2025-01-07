using Microsoft.EntityFrameworkCore;
using ShopManagement.AppServices;
using ShopManagement.AppServices.Contracts;
using ShopManagement.Domain.Repositories;
using ShopManagement.Infrastructures.Db;
using ShopManagement.Infrastructures.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
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
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{action=Index}/{controller=Home}/{id?}")
    .WithStaticAssets();


app.Run();
