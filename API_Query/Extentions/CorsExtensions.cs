using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace API_Query.Extentions
{
    /// <summary>
    /// Contains extension methods for set CORS up.
    /// </summary>
    public static class CorsExtensions
    {
        private const string CustomOrigins = "_customOrigins";

        /// <summary>
        /// Adds the CORS configuration to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">A service collection.</param>
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            //TODO: pending to review the allowed origins.
            services.AddCors(options =>
            {
                options.AddPolicy(name: CustomOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://sushiland-001-site6.ctempurl.com", "http://127.0.0.1:5500")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((x) => true)
                           .AllowCredentials();
                    });
            });

            return services;
        }

        /// <summary>
        /// Uses the CORS configuration for the specified <see cref="IApplicationBuilder"/>.
        /// </summary>
        /// <param name="app">An application builder.</param>
        public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors(CustomOrigins);

            return app;
        }
    }
}
