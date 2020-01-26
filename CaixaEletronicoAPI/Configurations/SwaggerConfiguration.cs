using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CaixaEletronicoAPI.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Caixa Eletronico",
                    Description = "API Caixa Eletronico ITAU",
                    TermsOfService = null,
                    Contact = new OpenApiContact { Name = "Desenvolvedor X", Email = "email@Teste.com"}                    
                });
            });
        }
    }
}
