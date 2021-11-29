namespace Millennium.Configuration
{
    public class Services
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSwaggerGen();
            services.AddMvc()
                    .AddXmlSerializerFormatters();

            return services;
        }
    }
}
