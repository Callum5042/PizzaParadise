using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities;
using Serilog;
using Serilog.Events;

namespace PizzaParadise.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("PizzaParadiseDb");

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Setup logging
            builder.Host.UseSerilog((context, config) =>
            {
                config.MinimumLevel.Override("Microsoft", LogEventLevel.Information);
                config.MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning);
                config.ReadFrom.Configuration(builder.Configuration);
                config.Enrich.FromLogContext();
            });

            // Register database
            builder.Services.AddDbContextFactory<PizzaParadiseContext>(opt =>
            {
                opt.UseSqlServer(connectionString, x => x.MigrationsAssembly("PizzaParadise.Entities"));
            });

            // Dependency injection

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapBlazorHub();

            app.Run();
        }
    }
}