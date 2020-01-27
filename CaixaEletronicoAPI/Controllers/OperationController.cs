using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.Application.Interface.IService;
using CaixaEletronico.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CaixaEletronicoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : Controller
    {
        private readonly IOperationService _service;

        public OperationController(IOperationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("Withdraw")]        
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Withdraw([FromBody] OperationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(new { Mensagem = await _service.Withdraw(model) });
                else
                    return BadRequest();
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

        [HttpPost]
        [Authorize]
        [Route("Deposit")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Deposit([FromBody] OperationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(new { Menssagem = await _service.Deposit(model) });
                else
                    return BadRequest();
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

        [HttpPost]
        [Authorize]
        [Route("Balance")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Balance([FromBody] OperationBalanceVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {                  
                    return Ok(new { Saldo =  await _service.Balance(model)});
                }
                else
                {
                    return BadRequest();
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Versão v01");
        }
    }
}