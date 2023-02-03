using DF.Infrastructure.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DF.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration) {

            var assembly = typeof(DoofastContext).Assembly.FullName;

            services.AddDbContext<DoofastContext>(
                options => options.UseSqlServer(
                        configuration.GetConnectionString("DoofastConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
              
            return services;

        }
    }
}
