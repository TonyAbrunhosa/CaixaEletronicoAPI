using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.ViewModel
{
    public class OperationViewModel
    {
        public string NUM_CONTA { get; set; }
        public string AGENCIA { get; set; }
        public string CPF { get; set; }
        public decimal VALOR { get; set; }
    }
}
