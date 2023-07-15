using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EFCore;
using Services.Contracts;
using WebApiBtk.Extensions;

var builder = WebApplication.CreateBuilder(args);

//nlog ayarlamas�
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

// Add services to the container.

builder.Services.AddControllers(config=>
{
    config.RespectBrowserAcceptHeader= true;//api mizi pazarl��a a�t�k.
    config.ReturnHttpNotAcceptable = true;//gelen talepleri kabul edip etmeme ile alakal� etmezsen 406 d�n.
})
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson();//putch i�in kullanm��t�k
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//context tan�m� vs  extension metotdan alaca��z.
builder.Services.ConfigureSqlContext(builder.Configuration);//2.parametreyi verdik ilkine gerek yok
builder.Services.ConfigureRepositoryManager();//
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();

builder.Services.AddAutoMapper(typeof(Program));//reflection ister

//IoC ye dbcontext tan�m�n� yapm�� olduk Art�k bu ayar� extension metotdan alaca��z.
//builder.Services.AddDbContext<RepositoryContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));



var app = builder.Build();
//extension metotta harici olarak gerekli logger parametresi vard�.Logger service ine ihtiyac�m var
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//sonradan ekledik
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
