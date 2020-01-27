using CaixaEletronico.Application.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Application.Validation
{
    public class TokenRequestValidation: AbstractValidator<TokenRequest>
    {
        public TokenRequestValidation()
        {
            RuleFor(c => c.AGENCIA).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a Agência.");
            RuleFor(c => c.NUM_CONTA).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a Número Conta.");
            RuleFor(c => c.SENHA).NotEmpty().NotNull().NotEqual("").WithMessage("Informe a senha.");
        }
        
    }
}
