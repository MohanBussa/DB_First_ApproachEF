using System.Web.Http;
using WebActivatorEx;
using Swagger_App;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Swagger_App
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
         
                        .EnableSwagger(c => c.SingleApiVersion("v1", "Demo"))
          .EnableSwaggerUi();
               
              
        }
    }
}
