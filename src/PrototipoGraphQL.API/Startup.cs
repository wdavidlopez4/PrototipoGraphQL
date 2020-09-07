using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrototipoGraphQL.API.context;
using PrototipoGraphQL.API.GraphQL.SchemaQL;

namespace PrototipoGraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //configurar db 
            services.AddDbContext<MemoryContext>(options => options.UseInMemoryDatabase(databaseName: "test"));

            //configuar servidor de pruebas para la api kestrel "se deme configurar con IIS para el despliege"
            services.Configure<KestrelServerOptions>(ops => { ops.AllowSynchronousIO = true; });

            //configurar graphql
            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));

            //configurar el schema
            services.AddScoped<MemorySchema>();

            //prueba schema 
            services.AddScoped<PruebaMemory>();

            //confirmar si se configuro graphql "muestra las execciones en tiempo de desarrollo"
            services.AddGraphQL(x => { x.ExposeExceptions = true; }).AddGraphTypes(ServiceLifetime.Scoped);



        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ejecutar graphql
            app.UseGraphQL<MemorySchema>();

            //prueba schema
            app.UseGraphQL<PruebaMemory>("/Prueba");

            //ejecutar playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
