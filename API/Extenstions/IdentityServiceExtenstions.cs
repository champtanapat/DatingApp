using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extenstions
{
    //static เพื่อไม่ต้อง new instance 
    public static class IdentityServiceExtenstions
    {
        public static IServiceCollection  IdentityServices (this IServiceCollection services,IConfiguration _config)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//
            .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true, 
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
                        ValidateIssuer =false,
                        ValidateAudience =false,
                    };
            });

            return services; 
        }
    }
}