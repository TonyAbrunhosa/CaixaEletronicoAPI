using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.Application.Interface.IRepository;
using CaixaEletronico.Application.Interface.IService;
using CaixaEletronico.Application.Service;
using CaixaEletronico.Infra.Repository;
using CaixaEletronico.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using CaixaEletronicoAPI.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CaixaEletronicoAPI
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
            services.AddControllers();

            services.AddSingleton<Accounts, Accounts>();
            services.AddTransient<IOperationService, OperationService>();
            services.AddTransient<IOperationRepository, OperationRepository>();

            services.AddSwaggerConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Caixa Eletronico v1.0");
            });
        }
    }
}
