using Microsoft.EntityFrameworkCore;
using ShopManagement.AppServices;
using ShopManagement.Domain.Contracts;
using ShopManagement.Framework;
using ShopManagement.Infrastructures.Db;
using ShopManagement.Infrastructures.Repositories;
using Microsoft.AspNetCore.Identity;
using ShopManagement.Domain.Entities;
using Serilog;
using Microsoft.Extensions.Logging.Configuration;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();



WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(o => {
    o.ClearProviders();
    o.AddSerilog();
}).UseSerilog((context, config) =>
{
    config.WriteTo.Console();
    config.WriteTo.Seq("http://localhost:5341", apiKey: "hLhiTpsEss5Ew4xZYBrf");
});


//builder.Logging.ClearProviders();

//if (builder.Environment.IsProduction())
//{
//builder.Logging.AddSerilog();
//}
//else
//{
//    builder.Logging.AddConsole();
//    builder.Logging.AddEventLog();
//}


    try
    {

        if (builder.Environment.IsProduction())
        {
        }

        ConfigurationManager configuration = builder.Configuration;

        //string universityName = configuration.GetSection("Settings:ApplicationName").Value;
        //Settings? settings = configuration.GetSection("SettingsModel").Get<Settings>();


        builder.Services.AddSingleton(configuration.GetSection("Settings").Get<SettingsModel>());


        // Add services to the container.
        builder.Services.AddControllersWithViews()
            .AddRazorRuntimeCompilation();

        builder.Services.AddRazorPages();


        //builder.Services.AddScoped<ShopDbContext, ShopDbContext>();
        string? connectionString = builder.Configuration.GetConnectionString("ShopDb");
        builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ShopDbContext>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductAppServices, ProductAppServices>();

        // https://go.microsoft.com/fwlink/?LinkID=532715
        //builder.Services.AddAuthentication()
        //   .AddGoogle(options =>
        //   {
        //       IConfigurationSection googleAuthNSection =
        //       config.GetSection("Authentication:Google");
        //       options.ClientId = googleAuthNSection["ClientId"];
        //       options.ClientSecret = googleAuthNSection["ClientSecret"];
        //   })
        //   .AddFacebook(options =>
        //   {
        //       IConfigurationSection FBAuthNSection =
        //       config.GetSection("Authentication:FB");
        //       options.ClientId = FBAuthNSection["ClientId"];
        //       options.ClientSecret = FBAuthNSection["ClientSecret"];
        //   })
        //   .AddMicrosoftAccount(microsoftOptions =>
        //   {
        //       microsoftOptions.ClientId = config["Authentication:Microsoft:ClientId"];
        //       microsoftOptions.ClientSecret = config["Authentication:Microsoft:ClientSecret"];
        //   })
        //   .AddTwitter(twitterOptions =>
        //   {
        //       twitterOptions.ConsumerKey = config["Authentication:Twitter:ConsumerAPIKey"];
        //       twitterOptions.ConsumerSecret = config["Authentication:Twitter:ConsumerSecret"];
        //       twitterOptions.RetrieveUserDetails = true;
        //   });

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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

        //if (app.Environment.IsEnvironment("Erfan"))
        //{
        //    app.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Home}/{action=Index}/{id?}")
        //        .WithStaticAssets();
        //}
        //else
        //{

        app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.MapRazorPages();

        app.Run();
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Application terminated unexpectedly");
    }
    finally
    {
        Log.CloseAndFlush();
    }