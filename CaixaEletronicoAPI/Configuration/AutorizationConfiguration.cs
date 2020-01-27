using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronicoApi.Configuration
{
    public static class AutorizationConfiguration
    {
        public static void AddMvcSecurity(this IServiceCollection services, IConfiguration configuration)
        {

            if (services == null) throw new ArgumentNullException(nameof(services));

            var tokenConfigurations = new JwtTokenOptions();
            new ConfigureFromConfigurationOptions<JwtTokenOptions>(
                    configuration.GetSection("JwtTokenOptions"))
                .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = tokenConfigurations.Issuer,

                ValidateAudience = true,
                ValidAudience = tokenConfigurations.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SigningCredentialsConfiguration.Key,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(t =>
            {
                t.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                t.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(t =>
            {
                t.RequireHttpsMetadata = false;
                t.SaveToken = true;
                t.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SigningCredentialsConfiguration.Key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.Configure<JwtTokenOptions>(options =>
            {
                options.Issuer = tokenConfigurations.Issuer;
                options.Audience = tokenConfigurations.Audience;
                options.MinutesValid = tokenConfigurations.MinutesValid;
                options.SigningCredentials = new SigningCredentialsConfiguration().SigningCredentials;
            });
        }
    }
}
