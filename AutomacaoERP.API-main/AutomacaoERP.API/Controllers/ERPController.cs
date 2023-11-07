using AutomacaoERP.API.ApplicationServices.Concretes;
using AutomacaoERP.API.ApplicationServices.Interfaces;
using AutomacaoERP.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutomacaoERP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ERPController : ControllerBase
    {
        private readonly ILogger<ERPController> _logger;
        private readonly IERPApplicationService _ierpApplicationService;
        private readonly IZenviaApplicationService _zenviaApplicationService;
        //private readonly IEncurtadorLinkApplicationService _iencurtadorLinkApplicationService;


        public ERPController(ILogger<ERPController> logger, IERPApplicationService ierpApplicationService, 
             IZenviaApplicationService zenviaApplicationService)
        {
            _logger = logger;
            _ierpApplicationService = ierpApplicationService;
            _zenviaApplicationService = zenviaApplicationService;
            //_iencurtadorLinkApplicationService = iencurtadorLinkApplicationService;
        }

        //[HttpGet("ConsultarCliente")]
        //public async Task<ActionResult<Cliente>> BuscarCliente(long idCliente)
        //{
        //    try
        //    {
        //        var response = await _ierpApplicationService.ConsultarCliente(idCliente);

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Ocorreu um erro: {0}", ex.Message);
        //        return StatusCode(500);
        //    }
        //}

        //[HttpGet("ConsultarContasReceber")]
        //public async Task<ActionResult<string>> BuscarContasReceber()
        //{
        //    try
        //    {
        //        var response = await _ierpApplicationService.ConsultarContasAReceber();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Ocorreu um erro: {0}", ex.Message);
        //        return StatusCode(500);
        //    }
        //}

        //[HttpGet("ConsultarListaClientes")]
        //public async Task<ActionResult<string>> BuscarClientes()
        //{
        //    try
        //    {
        //        var response = await _ierpApplicationService.ConsultarTodosClientes();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Ocorreu um erro: {0}", ex.Message);
        //        return StatusCode(500);
        //    }
        //}

        //[HttpGet("EncurtarLink")]
        //public async Task<ActionResult<string>> EncurtarLink(string link)
        //{
        //    try
        //    {
        //        var response = await _iencurtadorLinkApplicationService.EncurtarLink(link);

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Ocorreu um erro: {0}", ex.Message);
        //        return StatusCode(500);
        //    }
        //}

        [HttpGet("ConsultarMensagensZenvia")]
        public async Task<ActionResult<string>> ConsultarMensagensZenvia()
        {
            try
            {
                var response = await _ierpApplicationService.MontarMensagens();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocorreu um erro: {0}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("EnviarMensagensZenvia")]
        public async Task<ActionResult<string>> EnviarMensagemZenvia([FromBody] Mensagem smsZenvia)
        {
            try
            {
                //var mensagem = new Mensagem();
                //mensagem.celular = "5581987590333";
                //mensagem.link = "www.google.com" ;

                var response = await _zenviaApplicationService.EnviarMensagem(smsZenvia);

                return Ok(response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocorreu um erro: {0}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
