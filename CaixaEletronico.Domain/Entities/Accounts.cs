using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Domain.Entities
{
    public class Accounts
    {
        public Guid ID { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public string CONTA { get; set; }
        public string AGENCIA { get; set; }
        public string SENHA { get; set; }
        public decimal SALDO { get; set; }
    }    
}
