using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PizzaParadise.Blazor.Data;
using PizzaParadise.Data;
using PizzaParadise.Entities;

namespace Company.WebApplication1
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
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddDbContextFactory<PizzaParadiseContext>(opt => 
            {
                opt.UseSqlServer(connectionString, x => x.MigrationsAssembly("PizzaParadise.Migrations"));
            });

            builder.Services.AddSingleton(new TypeAdapterConfig());
            builder.Services.AddScoped<IMapper, ServiceMapper>();
            builder.Services.AddTransient<UserHandler>();

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

            app.Run();
        }
    }
}