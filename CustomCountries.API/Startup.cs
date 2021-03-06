using CustomCountries.API.Models;
using CustomCountries.API.Queries;
using CustomCountries.API.Services;
using CustomCountries.API.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace CustomCountries.API
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
            services.AddScoped<CountryService>();

            services.AddDbContext<RepositoryContext>(options =>
                options.UseNpgsql(new NpgsqlConnection(Configuration.GetConnectionString("CustomCountriesDB"))));

            //services.AddGraphQL(s => SchemaBuilder.New()
            //                        .AddServices(s)
            //                        .AddType<CountryType>()
            //                        .AddQueryType<CountryQuery>()
            //                        .Create());
            services
                .AddGraphQLServer()
                .AddType<CountryType>()
                .AddQueryType<CountryQuery>();

            //services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("CustomCountriesDB")));   
            //services.AddEntityFrameworkNpgsql()
            // .AddDbContext<CountryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("CustomCountriesDB")));           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/graphql",
                Path = "/playground"
            });

            //app.UseGraphQL("/api");

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();            

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            //app.UseGraphQL("/graphql");

            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();                    
                });
        }
    }
}
