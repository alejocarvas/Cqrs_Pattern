using MediatR;
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
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Cqrs_DataAccess.Command;
using Cqrs_DataAccess.Command.Interfaces;
using Cqrs_DataAccess.Command.Implementations;
using Microsoft.EntityFrameworkCore;
using Cqrs_Domain.Commands.Interfaces;
using Cqrs_Domain.Commands.Implementations;
using API_Command.Extentions;
using API_Command.Hub;

namespace API_Command
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
                    Title = $"Micro CQRS Commands {groupName}",
                    Version = groupName,
                    Description = "Micro CQRS Commands",
                    Contact = new OpenApiContact
                    {
                        Name = "Hexacta",
                        Email = string.Empty,
                        Url = new Uri("https://www.hexacta.com/"),
                    }
                });
            });

            services.AddDbContext<CommandContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserCommandService, UserCommandService>();
            services.AddScoped<IMovieCommandService, MovieCommandService>();
            services.AddTransient<IUserCommandRepository, UserCommandRepository>();
            services.AddTransient<IMovieCommandRepository, MovieCommandRepository>();

            // Register SignalR
            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });
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
                endpoints.MapHub<CqrsPatternHub>("/CqrsPatternHub");
            });
        }
    }
}
