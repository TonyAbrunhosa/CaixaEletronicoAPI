using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CaixaEletronico.Application.ViewModel;
using CaixaEletronico.Domain.Entities;
using CaixaEletronicoApi.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CaixaEletronico.Application.Interface.IService;

namespace CaixaEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizationController : Controller
    {
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly IAutorizationService _service;
        public AutorizationController(IAutorizationService service, IOptions<JwtTokenOptions> jwtTokenOptions)
        {
            _jwtTokenOptions = jwtTokenOptions.Value;
            _service = service;
        }

        [HttpPost]
        [Route("Token")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerationToken(TokenRequest model)
        {
            try
            {
                Accounts accounts = await _service.GetAccounts(model);

                if (accounts != null)
                {
                    return Ok(await GerarTokenUsuario(accounts));
                }
                else
                {
                    return BadRequest(new { Mensagem = "Cliente não encontrado, verifique os dados informados." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Resultado = false,
                    Erro = ex.Message,
                    PilhaErro = ex.StackTrace
                });
            }
        }

        private async Task<TokenViewModel> GerarTokenUsuario(Accounts accounts)
        {
            TokenViewModel token = new TokenViewModel();

            Task ts = new Task(delegate ()
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, accounts.NOME));
                claims.Add(new Claim(JwtRegisteredClaimNames.NameId, accounts.CPF));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                var std = new SecurityTokenDescriptor()
                {
                    Issuer = _jwtTokenOptions.Issuer,
                    Audience = _jwtTokenOptions.Audience,
                    Subject = new ClaimsIdentity(claims),
                    NotBefore = DateTime.Now,
                    Expires = DateTime.Now.AddMinutes(_jwtTokenOptions.MinutesValid),
                    SigningCredentials = new SigningCredentialsConfiguration().SigningCredentials
                };

                SecurityToken securityToken = new JwtSecurityTokenHandler().CreateToken(std);

                token.date_generation = DateTime.Now;
                token.expires_in = DateTime.Now.AddMinutes(_jwtTokenOptions.MinutesValid);
                token.access_token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            });

            ts.Start();
            await ts;

            return token;
        }
    }
}