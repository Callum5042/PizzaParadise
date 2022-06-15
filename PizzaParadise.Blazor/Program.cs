using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PizzaParadise.Blazor.Data;
using PizzaParadise.Data;
using PizzaParadise.Entities;
using Serilog;
using Serilog.Events;

namespace PizzaParadise.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("PizzaParadiseDb");

            // Setup logging
            builder.Host.UseSerilog((context, config) =>
            {
                config.MinimumLevel.Override("Microsoft", LogEventLevel.Information);
                config.MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning);
                config.ReadFrom.Configuration(builder.Configuration);
                config.Enrich.FromLogContext();
            });

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Add services to the container.
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddDbContextFactory<PizzaParadiseContext>(opt =>
            {
                opt.UseSqlServer(connectionString, x => x.MigrationsAssembly("PizzaParadise.Migrations"));
            });

            builder.Services.AddSingleton(new TypeAdapterConfig());
            builder.Services.AddScoped<IMapper, ServiceMapper>();
            builder.Services.AddTransient<CreateUserAction>();
            builder.Services.AddTransient<ListUserAction>();
            builder.Services.AddTransient<ProductCategoriesRepository>();
            builder.Services.AddTransient<ProductCreateAction>();

            builder.Services.AddLocalization();

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.UseRequestLocalization("en-GB");

            // Apply migrations
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PizzaParadiseContext>();
                context.Database.Migrate();
            }

            app.Run();
        }
    }
}