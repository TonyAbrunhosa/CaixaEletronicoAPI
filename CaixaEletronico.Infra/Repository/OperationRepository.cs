using CaixaEletronico.Application.Interface.IRepository;
using CaixaEletronico.Application.ViewModel;
using CaixaEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Infra.Repository
{
    public class OperationRepository : IOperationRepository
    {
		private static List<Accounts> ListAccounts = new List<Accounts>();

		public OperationRepository()
		{
			if (ListAccounts.Count == 0)
			{
				CreateAccout();
			}			
		}

		public async void ExecuteTransaction(OperationViewModel model, decimal valor)
		{
			try
			{
				Accounts account = await Task.Run(() => account = ListAccounts.FirstOrDefault(t => t.CONTA.Equals(model.NUM_CONTA) && t.CPF.Equals(model.CPF) && t.AGENCIA.Equals(model.AGENCIA)));

				account.SALDO = valor;
			}
			catch (Exception ex)
			{
				throw new InfraException($"Internal server erro - OperationRepository \n\n{ex.Message}", ex);
			}
		}

		public async Task<Accounts> GetAccounts(TokenRequest model)
		{
			try
			{
				return await Task.Run(() => ListAccounts.FirstOrDefault(t => t.SENHA.Equals(model.SENHA) && t.CONTA.Equals(model.NUM_CONTA) && t.AGENCIA.Equals(model.AGENCIA)));
			}
			catch (Exception ex)
			{
				throw new InfraException($"Internal server erro - OperationRepository \n\n{ex.Message}", ex);
			}
		}

		public async Task<Accounts> GetBalance(string AGENCIA,string NUM_CONTA)
        {
			try
			{			
				return await Task.Run(() => ListAccounts.FirstOrDefault(t => t.CONTA.Equals(NUM_CONTA) && t.AGENCIA.Equals(AGENCIA)));
			}
			catch (Exception ex)
			{
				throw new InfraException($"Internal server erro - OperationRepository \n\n{ex.Message}", ex);
			}
        }



		private void CreateAccout()
		{		
			ListAccounts.Add(new Accounts { ID = Guid.NewGuid(), NOME = "José da Silva", CPF = "12345678909", CONTA = "000001-6", AGENCIA = "1203", SALDO = 356.50m, SENHA = "@eletronico@" });
			ListAccounts.Add(new Accounts { ID = Guid.NewGuid(), NOME = "João da Silva", CPF = "51583455116", CONTA = "000012-6", AGENCIA = "0249", SALDO = 1356.50m, SENHA = "@eletronico@" });
			ListAccounts.Add(new Accounts { ID = Guid.NewGuid(), NOME = "Emanuel Santos", CPF = "20588441228", CONTA = "000132-6", AGENCIA = "0178", SALDO = 956.50m, SENHA = "@eletronico@" });
			ListAccounts.Add(new Accounts { ID = Guid.NewGuid(), NOME = "Maria Santos Silva", CPF = "85676915161", CONTA = "003215-6", AGENCIA = "0325", SALDO = 9856.50m, SENHA = "@eletronico@" });
			ListAccounts.Add(new Accounts { ID = Guid.NewGuid(), NOME = "Isaac Abrunhosa", CPF = "73450638360", CONTA = "096523-6", AGENCIA = "0123", SALDO = 21456.50m, SENHA = "@eletronico@" });
		}
	}
}
