using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Application.ViewModel
{
    public class TokenRequest
    {
        public string NUM_CONTA { get; set; }
        public string AGENCIA { get; set; }
        public string SENHA { get; set; }
    }
}
