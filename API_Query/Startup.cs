using API_Query.Extentions;
using Cqrs_DataAccess.Query;
using Cqrs_DataAccess.Query.Implementations;
using Cqrs_DataAccess.Query.Interfaces;
using Cqrs_Domain.Queries.Implementations;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace API_Query
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
            services.AddCustomCors();
            services.AddControllers();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Micro CQRS Queries {groupName}",
                    Version = groupName,
                    Description = "Micro CQRS Queries",
                    Contact = new OpenApiContact
                    {
                        Name = "Hexacta",
                        Email = string.Empty,
                        Url = new Uri("https://www.hexacta.com/"),
                    }
                });
            });

            services.AddDbContext<QueryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserQueryService, UserQueryService>();
            services.AddScoped<IMovieQueryService, MovieQueryService>();
            services.AddTransient<IUserQueryRepository, UserQueryRepository>();
            services.AddTransient<IMovieQueryRepository, MovieQueryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();

            app.UseCustomCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
