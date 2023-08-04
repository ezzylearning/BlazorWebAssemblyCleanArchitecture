using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection; 

namespace BlazorWebAssemblyCleanArchitecture.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMediator(); 
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }    
    }
}
