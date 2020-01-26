using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.Application.Interface.IService;
using CaixaEletronico.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [Route("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] OperationViewModel model)
        {
            try
            {
                return Ok(await _service.Withdraw(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        [HttpPost]
        [Route("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] OperationViewModel model)
        {
            try
            {
                return Ok(await _service.Deposit(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        [Route("Deposit")]
        public async Task<IActionResult> Balance([FromBody] OperationViewModel model)
        {
            try
            {
                return Ok(await _service.Balance(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest();
        }
    }
}