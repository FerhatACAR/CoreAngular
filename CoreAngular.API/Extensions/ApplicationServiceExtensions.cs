using CoreAngular.API.Data;
using CoreAngular.API.Interfaces;
using CoreAngular.API.Services;
using Microsoft.EntityFrameworkCore;

namespace CoreAngular.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => 
            {
                options.UseOracle(config.
                    GetConnectionString("OraDbConnection"));    
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}