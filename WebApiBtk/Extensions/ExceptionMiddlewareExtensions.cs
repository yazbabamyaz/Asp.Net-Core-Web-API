using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;
using System.Net;

namespace WebApiBtk.Extensions
{
    //WebApplication class ı için bir eklenti sınıfı yazdık
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,ILoggerService logger)
        {
            app.UseExceptionHandler(appError=>
            {
                appError.Run(async context =>
                {
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//500
                    context.Response.ContentType="application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();//hata var mı
                    //context in IExceptionHandlerFeature böyle bir özelliği varsa demek ki hata var 
                    if (contextFeature is not null)//hata varsa
                    {

                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _=>StatusCodes.Status500InternalServerError
                        };
                        logger.LogError($"Something went wrong:{contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails() {
                         StatusCode= context.Response.StatusCode,
                          Message=contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
