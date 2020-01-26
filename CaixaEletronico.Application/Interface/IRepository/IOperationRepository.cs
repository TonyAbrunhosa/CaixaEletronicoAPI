using CaixaEletronico.Application.ViewModel;
using CaixaEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Interface.IRepository
{
    public interface IOperationRepository
    {
        Task<Accounts> GetBalance(string AGENCIA, string NUM_CONTA);
        Task<Accounts> GetAccounts(TokenRequest model);
        void ExecuteTransaction(OperationViewModel model, decimal valor); 
    }
}
