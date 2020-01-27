using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronicoApi.Configuration
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int MinutesValid { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
