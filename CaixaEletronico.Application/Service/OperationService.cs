using CaixaEletronico.Application.Interface.IRepository;
using CaixaEletronico.Application.Interface.IService;
using CaixaEletronico.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Service
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public async Task<decimal> Balance(OperationBalanceVM model)
        {
            var account = await _operationRepository.GetBalance(model.AGENCIA, model.NUM_CONTA);
            return account.SALDO;
        }

        public async Task<string> Deposit(OperationViewModel model)
        {
            var accout = await _operationRepository.GetBalance(model.AGENCIA, model.NUM_CONTA);

            decimal saldo = (accout.SALDO + model.VALOR);
            _operationRepository.ExecuteTransaction(model, saldo);

            return "Deposito realizado com sucesso!";
        }

        public async Task<string> Withdraw(OperationViewModel model)
        {
            var accout = await _operationRepository.GetBalance(model.AGENCIA,model.NUM_CONTA);

            if (accout.SALDO < model.VALOR)
                return "Saldo insuficiente";
            else
            {
                decimal saldo = (accout.SALDO - model.VALOR);
                _operationRepository.ExecuteTransaction(model, saldo);
            }

            return "Saque realizado com sucesso!";
        }
    }
}
