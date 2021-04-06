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
using CustomCountries.API.Services;
using CustomCountries.API.GraphQl.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CustomCountries.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>();
            services.AddScoped<ICountryService, CountryService>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/customcountries-c4790";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/customcountries-c4790",
                        ValidateAudience = true,
                        ValidAudience = "customcountries-c4790",
                        ValidateLifetime = true
                    };
                });

            services.AddAuthorization();

            services
                .AddGraphQLServer()
                .AddType<CountryType>()
                .AddQueryType(x => x.Name("QueriesCustomContries"))
                .AddTypeExtension<CountryQuery>()
                .AddTypeExtension<UrlGitHubQuery>()                
                .AddMutationType<CountryMutation>()
                .AddErrorFilter<ErrorFilter>()
                .AddAuthorization();

            services.AddCors(option => {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("allowedOrigin");
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
