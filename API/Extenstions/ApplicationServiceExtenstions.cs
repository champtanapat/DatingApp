using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extenstions
{
    //static เพื่อไม่ต้อง new instance 
    public static class ApplicationServiceExtenstions
    {
        public static IServiceCollection  ApplicationServices (this IServiceCollection services,IConfiguration _config)
        {

            services.AddScoped<ITokenService,TokenService>();//
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });

            return services; 
        }
    }
}