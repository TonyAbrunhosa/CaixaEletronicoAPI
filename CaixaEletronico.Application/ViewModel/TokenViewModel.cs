using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Application.ViewModel
{
    public class TokenViewModel
    {
        public DateTime date_generation { get; set; }
        public DateTime expires_in { get; set; }
        public string access_token { get; set; }
    }
}
