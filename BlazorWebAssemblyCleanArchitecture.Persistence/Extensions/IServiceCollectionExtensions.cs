using BlazorWebAssemblyCleanArchitecture.Application.Interfaces.Repositories;
using BlazorWebAssemblyCleanArchitecture.Persistence.Contexts;
using BlazorWebAssemblyCleanArchitecture.Persistence.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyCleanArchitecture.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        //private static void AddMappings(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //}

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IStadiumRepository, StadiumRepository>();
        }
    }
}
