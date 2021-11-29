using Millennium.Models;
using Millennium.Persistance;

namespace Millennium.Configuration
{
    public class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            // Would be transient but list is in memory
            services.AddSingleton<IPersonRepository, PersonRepository>();
            //services.AddTransient<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}
