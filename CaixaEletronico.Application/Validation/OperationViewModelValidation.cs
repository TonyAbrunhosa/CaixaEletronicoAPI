using CaixaEletronico.Application.ViewModel;
using FluentValidation;


namespace CaixaEletronico.Application.Validation
{
    public class OperationViewModelValidation : AbstractValidator<OperationViewModel>
    {
        public OperationViewModelValidation()
        {
            RuleFor(c => c.AGENCIA).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a Agência.");
            RuleFor(c => c.NUM_CONTA).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a Número Conta.");
            RuleFor(c => c.CPF).NotEmpty().NotNull().NotEqual("").WithMessage("Informe o CPF.");            
            RuleFor(c => c.VALOR).NotEmpty().NotNull().GreaterThan(0).WithMessage("Informe o Valor.");
        }
    }
}
