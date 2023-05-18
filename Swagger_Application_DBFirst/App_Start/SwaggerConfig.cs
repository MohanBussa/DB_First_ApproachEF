using System.Web.Http;
using WebActivatorEx;
using Swagger_Application_DBFirst;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Swagger_Application_DBFirst
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                     
                        c.SingleApiVersion("v1", "Swagger_Application_DBFirst");

                      
                    })
                .EnableSwaggerUi(c =>
                    {
                
                    });
        }
    }
}
