using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EFCore;
using Services.Contracts;
using WebApiBtk.Extensions;

var builder = WebApplication.CreateBuilder(args);

//nlog ayarlamasý
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

// Add services to the container.

builder.Services.AddControllers(config=>
{
    config.RespectBrowserAcceptHeader= true;//api mizi pazarlýða açtýk.
    config.ReturnHttpNotAcceptable = true;//gelen talepleri kabul edip etmeme ile alakalý etmezsen 406 dön.
})
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson();//putch için kullanmýþtýk
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//context tanýmý vs  extension metotdan alacaðýz.
builder.Services.ConfigureSqlContext(builder.Configuration);//2.parametreyi verdik ilkine gerek yok
builder.Services.ConfigureRepositoryManager();//
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();

builder.Services.AddAutoMapper(typeof(Program));//reflection ister

//IoC ye dbcontext tanýmýný yapmýþ olduk Artýk bu ayarý extension metotdan alacaðýz.
//builder.Services.AddDbContext<RepositoryContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));



var app = builder.Build();
//extension metotta harici olarak gerekli logger parametresi vardý.Logger service ine ihtiyacým var
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
