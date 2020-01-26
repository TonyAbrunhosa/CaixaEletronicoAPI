using CaixaEletronico.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Interface.IService
{
    public interface IOperationService
    {
        Task<string> Deposit(OperationViewModel model);
        Task<string> Withdraw(OperationViewModel model);
        Task<decimal> Balance(OperationBalanceVM model);
    }
}
