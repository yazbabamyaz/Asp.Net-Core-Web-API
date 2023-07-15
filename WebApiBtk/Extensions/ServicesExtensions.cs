using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApiBtk.Extensions
{
    //ex metotları static classlara yazarız. static class üyeleri de static olur
    public static class ServicesExtensions
    {
        //HANGİ İFADEYİ GENİŞLETMEK İSTİYORSAN başına this koy.IServiceCollection bunu genişletmek istedik.
        //Artık bu ayaraları ex metot üzerinden çekecez.
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager,RepositoryManager>();
        }

        //servicemanager ın IoC  kaydı
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services) 
        { 
            services.AddSingleton<ILoggerService,LoggerManager>();
        }
    }
}
