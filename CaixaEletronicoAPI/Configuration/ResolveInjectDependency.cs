using CaixaEletronico.Application.Interface.IRepository;
using CaixaEletronico.Application.Interface.IService;
using CaixaEletronico.Application.Service;
using CaixaEletronico.Application.Validation;
using CaixaEletronico.Application.ViewModel;
using CaixaEletronico.Infra.Repository;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CaixaEletronicoApi.Configuration
{
    public static class ResolveInjectDependency
    {
        public static void Resolve(this IServiceCollection services)
        {
            services.AddTransient<IOperationService, OperationService>();
            services.AddTransient<IAutorizationService, AutorizationService>();
            services.AddTransient<IOperationRepository, OperationRepository>();
            services.AddTransient<IValidator<OperationViewModel>, OperationViewModelValidation>();
            services.AddTransient<IValidator<OperationBalanceVM>, OperationBalanceVMValidation>();
            services.AddTransient<IValidator<TokenRequest>, TokenRequestValidation>();
        }
    }
}
