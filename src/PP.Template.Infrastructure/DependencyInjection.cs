using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PP.Template.Application.Interfaces;
using PP.Template.Infrastructure.Database;

namespace PP.Template.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            string connectionString = Environment.GetEnvironmentVariable("PP.Template.Api:ConnectionString") 
                ?? configuration["PP.Template.Api:ConnectionString"].ToString();
            
            services.AddDbContext<ApplicationDbContext>(o=> { o.UseSqlServer(connectionString); });
        }
    }
}
