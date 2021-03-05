using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
            //services.AddSingleton<IDependencyResolver>(
            //    s => new FuncDependencyResolver(s.GetRequiredService)
            //);

            //services.AddHttpClient<IMovieService, MovieService>();
            //services.AddSingleton<MovieQuery>();
            //services.AddSingleton<MovieType>();
            //services.AddSingleton<ResultsType<MovieType, Movie>>();
            //services.AddSingleton<MainSchema>();

            //services.AddScoped<IDependencyResolver>(_ => new
            //FuncDependencyResolver(_.GetRequiredService));
            //services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            //services.AddScoped<IDocumentWriter, DocumentWriter>();
            //services.AddScoped<AuthorService>();
            //services.AddScoped<AuthorRepository>();
            //services.AddScoped<AuthorQuery>();
            //services.AddScoped<AuthorType>();
            //services.AddScoped<BlogPostType>();
            //services.AddScoped<ISchema, GraphQLDemoSchema>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app
            .UseCors()
            .UseWebSockets()
            .UseGraphQLPlayground(new GraphQLPlaygroundOptions() { Path = "/" });

            app.UseRouting();

            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
