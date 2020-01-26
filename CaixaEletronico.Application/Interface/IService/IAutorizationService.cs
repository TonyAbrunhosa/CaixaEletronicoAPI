using CaixaEletronico.Application.ViewModel;
using CaixaEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Interface.IService
{
    public interface IAutorizationService
    {
        Task<Accounts> GetAccounts(TokenRequest model);
    }
}
