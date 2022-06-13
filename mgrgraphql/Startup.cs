using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mgrapi;
using mgrapi.Interfaces;
using mgrapi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace mgrgraphql
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // services.AddInMemorySubscriptions();

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            // services.AddTransient<ICategoriesService, CategoriesService>();
            // services.AddTransient<IPostsService, PostsService>();
            // services.AddTransient<IUsersService, UsersService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IPostsService, PostsService>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddDbContext<RepositoryContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn"))); 

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mgrgraphql", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mgrgraphql v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                }); 
        }
    }
}
