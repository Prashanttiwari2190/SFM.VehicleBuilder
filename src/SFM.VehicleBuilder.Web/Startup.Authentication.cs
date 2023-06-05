using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SFM.VehicleBuilder.Web.Configuration;

namespace SFM.VehicleBuilder.Web
{
    /// <summary>
    ///   Extensions for and <see cref="IApplicationBuilder"/> object.
    /// </summary>
    internal static partial class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder app, bool authnEnabled = true)
        {
            if (authnEnabled)
                app.UseAuthentication();

            return app;
        }
    }

    /// <summary>
    ///   Extensions for and <see cref="IServiceCollection"/> object.
    /// </summary>
    [SuppressMessage("Maintainability Rules", "SA1402", Justification = "Related Configuration and Startup Extensions")]
    internal static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration
                .GetSection(AuthenticationConfiguration.SectionName)
                .Get<AuthenticationConfiguration>();

            if (config.Enabled == false)
            {
                // WARNING: Authentication is disabled!
                Console.WriteLine("The application has disabled authentication!");

                // This MUST be registered as a transient to prevent a bug with the AuthenticationTokenPassinghttpMessageHandler
                services.AddTransient(provider => config.UseFake
                    ? new Application.Authentication.AuthenticationToken(config.FakeUserId, config.FakeUserName)
                    : Application.Authentication.AuthenticationToken.Anonymous);

                return services;
            }

            // Add and configure the JWT Bearer token authentication scheme.
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.Audience = config.Audience;
                    options.Authority = config.Authority;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudience = config.Audience,
                        ValidateIssuer = true,
                        ValidIssuer = config.Authority,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.FromMinutes(5),
                        NameClaimType = config.UpnClaim,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = authFailed =>
                        {
                            Console.WriteLine(authFailed.Exception.ToString(), "JWT token validation failed!");
                            return Task.CompletedTask;
                        },
                    };
                });

            // Add our custom AuthenticationToken to the container. IT MUST be registered as a transient to prevent a
            // bug with the AuthenticationTokenPassingHttpMessageHandler
            services
                .AddTransient(provider =>
                {
                    var httpContext = provider
                        .GetRequiredService<IHttpContextAccessor>()
                        .HttpContext;

                    var tokenValue = httpContext
                        ?.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token")
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();

                    if (string.IsNullOrEmpty(tokenValue))
                    {
                        Console.WriteLine("The Bearer token was not found in the request header. The current user will be treated as Anonymous.");
                        return Application.Authentication.AuthenticationToken.Anonymous;
                    }

                    var token = new JwtSecurityToken(tokenValue);

                    var userId = token.Claims
                        .FirstOrDefault(claim => claim.Type.Equals(config.UpnClaim, StringComparison.OrdinalIgnoreCase))
                        ?.Value;

                    if (string.IsNullOrEmpty(userId))
                    {
                        Console.WriteLine("The UserId could not be determined because the 'upn' claim was not found. The current user will be treated as Anonymous.");
                        return Application.Authentication.AuthenticationToken.Anonymous;
                    }

                    var userName = token.Claims
                        .FirstOrDefault(claim => claim.Type.Equals(config.NameClaim, StringComparison.OrdinalIgnoreCase))
                        ?.Value;

                    return new Application.Authentication.AuthenticationToken(userId, userName, token);
                });

            return services;
        }
    }
}