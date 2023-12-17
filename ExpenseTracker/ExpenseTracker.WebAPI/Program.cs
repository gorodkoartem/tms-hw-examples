using ExpenseTracker.BL.Automapper;
using ExpenseTracker.BL.Services;
using ExpenseTracker.BL.Services.Interfaces;
using ExpenseTracker.DAL;
using ExpenseTracker.WebAPI.Automapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ExpenseTrackerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IAccountService, AccountService>();

        builder.Services.AddAutoMapper(typeof(DalBlMappingProfile), typeof(DtoBlMappingProfile));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
