using CaixaEletronico.Application.Interface.IRepository;
using CaixaEletronico.Application.Interface.IService;
using CaixaEletronico.Application.ViewModel;
using CaixaEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Service
{    
    public class AutorizationService : IAutorizationService
    {
        private readonly IOperationRepository _operationRepository;

        public AutorizationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }
        public async Task<Accounts> GetAccounts(TokenRequest model)
        {
            return await _operationRepository.GetAccounts(model);            
        }
    }
}
