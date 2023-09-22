using Microsoft.AspNetCore.Mvc;
using Sandbox.Services;

namespace Sandbox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPersonService, PersonService>();

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
                name: "person-routing",
                pattern: "person/{action}/{name}",
                defaults: new
                {
                    controller = "Person"
                });

            app.MapControllerRoute(
    name: "person-routing1",
    pattern: "Home/Index",
    defaults: new
    {
        controller = "Home",
        action = "Index2"
    });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}");

            app.Run();
        }
    }
}