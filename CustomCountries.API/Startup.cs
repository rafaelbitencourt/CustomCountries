using CustomCountries.API.Models;
using CustomCountries.API.GraphQl.Queries;
using CustomCountries.API.GraphQl.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CustomCountries.API.GraphQl.Mutations;
using CustomCountries.API.Repository;

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
            services.AddSingleton(new CountryService());

            services.AddDbContext<DataBaseContext>();

            services
                .AddGraphQLServer()
                .AddType<CountryType>()
                .AddQueryType<CountryQuery>()
                .AddMutationType<CountryMutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/graphql",
                Path = "/playground"
            });

            app.UseEndpoints(x => x.MapGraphQL());
        }
    }
}
