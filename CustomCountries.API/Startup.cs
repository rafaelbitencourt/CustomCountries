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
using CustomCountries.API.Repositories;
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
            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));

            services.AddDbContext<DataBaseContext>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IRepCountry, RepCountry>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration.GetSection("TokenSettings").GetValue<string>("Issuer"),
                        ValidateIssuer = true,
                        ValidAudience = Configuration.GetSection("TokenSettings").GetValue<string>("Audience"),
                        ValidateAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("TokenSettings").GetValue<string>("Key"))),
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddAuthorization();

            services
                .AddGraphQLServer()
                .AddType<CountryType>()
                .AddQueryType(x => x.Name("QueriesCustomContries"))
                .AddTypeExtension<CountryQuery>()
                .AddTypeExtension<LoginQuery>()             
                .AddMutationType<CountryMutation>()
                .AddErrorFilter<ErrorFilter>()
                .AddAuthorization();

            services.AddCors(option => {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("allowedOrigin");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/graphql",
                Path = "/playground"
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}
