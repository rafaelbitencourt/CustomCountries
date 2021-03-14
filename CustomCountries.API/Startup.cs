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
            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));

            services.AddDbContext<DataBaseContext>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddHttpContextAccessor();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = true,
            //        ValidateIssuer = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidAudience = "audience",
            //        ValidIssuer = "issuer",
            //        RequireSignedTokens = false,
            //        IssuerSigningKey =
            //            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretsecretsecret"))
            //    };

            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //});

            services
                .AddGraphQLServer()
                .AddType<CountryType>()
                .AddQueryType(x => x.Name("QueriesCustomContries"))
                .AddTypeExtension<CountryQuery>()
                .AddTypeExtension<LoginQuery>()
                .AddTypeExtension<UrlGitHubQuery>()                
                .AddMutationType<CountryMutation>()
                .AddErrorFilter<ErrorFilter>();

            services.AddCors(option => {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

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
