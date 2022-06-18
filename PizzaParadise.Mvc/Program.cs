using Microsoft.AspNetCore.Mvc.Razor;

namespace PizzaParadise.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Customise razor view search locations
            builder.Services.Configure<RazorViewEngineOptions>(options =>
            {
                // {2} is area, {1} is controller,{0} is the action
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/site/{1}/{0}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/site/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/site/shared/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/site/{1}/{0}/_{0}" + RazorViewEngine.ViewExtension);

                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/site/{2}/{1}/{0}/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/site/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/site/{2}/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/site/shared/{0}" + RazorViewEngine.ViewExtension);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}