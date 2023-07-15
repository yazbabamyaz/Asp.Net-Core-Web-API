using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace WebApiBtk.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        //görevi dbcontext oluşturmak
        public RepositoryContext CreateDbContext(string[] args)
        {
            //2 tanım yapcaz
            //1-Configuration: appsettinge ulaşmak amacı var
           
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //2-DbContextOptionsBuilder ifadesi yazcaz
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                prj=>prj.MigrationsAssembly("WebApiBtk")); 
            //Migrationlar webApiBtk katmanında-Assembly sinde- oluşsun dedik ve options oluşturduk


            //contextimizi newleyerek geri döndük
            return new RepositoryContext(builder.Options);
        }
    }
}
