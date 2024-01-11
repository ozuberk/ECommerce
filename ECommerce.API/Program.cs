using ECommerce.Core.IRepositories;
using ECommerce.Core.IService;
using ECommerce.Core.IUnitOfWork;
using ECommerce.Repository;
using ECommerce.Repository.Repositories;
using ECommerce.Repository.UnitOfWork;
using ECommerce.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddSwaggerDocument();




            #region DB inilitian

            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });

            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseOpenApi();
            app.UseSwaggerUi();



            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
