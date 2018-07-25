using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapptaApi.Models;
using CapptaApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapptaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService ?? throw new ArgumentNullException(nameof(transacaoService));
        }

        [HttpGet("ConsultaPorAdquirente/{adquirente}/{bandeira}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorAdquirente(string adquirente, string bandeira)
        {
            var result = await _transacaoService.ConsultaPorAdquirente(adquirente, bandeira);
            return Ok(result);
        }

        [HttpGet("ConsultaPorBandeira/{bandeira}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorBandeira(string bandeira)
        {
            var result = await _transacaoService.ConsultaPorBandeira(bandeira);
            return Ok(result);
        }

        [HttpGet("consultaporcnpj/{cnpj}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpj(string cnpj)
        {
            var result = await _transacaoService.ConsultaPorCnpj(cnpj);
            return Ok(result);
        }

        [HttpGet("consultaporcnpjdataatualmastercard/{cnpj}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpjDataAtualMastercard(string cnpj)
        {
            var result = await _transacaoService.ConsultaPorCnpjDataAtualMastercard(cnpj);
            return Ok(result);
        }

        [HttpGet("consultaporcnpjebandeira/{cnpj}/{bandeira}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpjEBandeira(string cnpj, string bandeira)
        {
            var result = await _transacaoService.ConsultaPorCnpjEBandeira(cnpj, bandeira);
            return Ok(result);
        }

        [HttpGet("consultaporcnpjmasterevisa/{cnpj}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpjMasterEVisa(string cnpj)
        {
            var result = await _transacaoService.ConsultaPorCnpjMasterEVisa(cnpj);
            return Ok(result);
        }

        [HttpGet("consultaporcnpjstoneultimos30dias/{cnpj}}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpjStoneUltimos30Dias(string cnpj)
        {
            var result = await _transacaoService.ConsultaPorCnpjStoneUltimos30Dias(cnpj);
            return Ok(result);
        }

        [HttpGet("consultapordata/{data}/{bandeira}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorData(string data,string bandeira)
        {
            DateTime dataConvertida = DateTime.Now;
            DateTime.TryParse(data,out dataConvertida);
            var result = await _transacaoService.ConsultaPorData(dataConvertida, bandeira);
            return Ok(result);
        }
    }
}