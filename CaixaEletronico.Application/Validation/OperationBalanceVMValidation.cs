using CaixaEletronico.Application.ViewModel;
using FluentValidation;

namespace CaixaEletronico.Application.Validation
{
    public class OperationBalanceVMValidation : AbstractValidator<OperationBalanceVM>
    {
        public OperationBalanceVMValidation()
        {
            RuleFor(c => c.AGENCIA).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a Agência."); 
            RuleFor(c => c.NUM_CONTA).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a Número Conta.");
        }
    }
}
