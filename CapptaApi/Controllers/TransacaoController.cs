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

        [HttpGet("consultaporadquirente/{adquirente}/{bandeira}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorAdquirente(string adquirente, string bandeira)
        {
            try
            {
                var result = await _transacaoService.ConsultaPorAdquirente(adquirente, bandeira);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        [HttpGet("consultaporbandeira/{bandeira}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorBandeira(string bandeira)
        {
            try
            {
                var result = await _transacaoService.ConsultaPorBandeira(bandeira);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        [HttpGet("consultaporcnpj/{cnpj}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpj(string cnpj)
        {
            try
            {
                var result = await _transacaoService.ConsultaPorCnpj(cnpj);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        [HttpGet("consultaporcnpjdataatualmastercard/{cnpj}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpjDataAtualMastercard(string cnpj)
        {
            try
            {
                var result = await _transacaoService.ConsultaPorCnpjDataAtualMastercard(cnpj);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        [HttpGet("consultaporcnpjebandeira/{cnpj}/{bandeira}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpjEBandeira(string cnpj, string bandeira)
        {
            try
            {
                var result = await _transacaoService.ConsultaPorCnpjEBandeira(cnpj, bandeira);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        [HttpGet("consultaporcnpjmasterevisa/{cnpj}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpjMasterEVisa(string cnpj)
        {
            try
            {
                var result = await _transacaoService.ConsultaPorCnpjMasterEVisa(cnpj);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        [HttpGet("consultaporcnpjstoneultimos30dias/{cnpj}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorCnpjStoneUltimos30Dias(string cnpj)
        {
            try
            {
                var result = await _transacaoService.ConsultaPorCnpjStoneUltimos30Dias(cnpj);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpGet("consultapordata/{data}/{bandeira}")]
        [ProducesResponseType(typeof(IEnumerable<Transacao>), 200)]
        public async Task<IActionResult> ConsultaPorData(string data,string bandeira)
        {
            try
            {
                var dia = int.Parse(data.Substring(0,2));
                var mes = int.Parse(data.Substring(2, 2));
                var ano = int.Parse(data.Substring(4, 4));

                var dataConvertida = new DateTime(ano,mes,dia);
                var result = await _transacaoService.ConsultaPorData(dataConvertida, bandeira);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }
    }
}