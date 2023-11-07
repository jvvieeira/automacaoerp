using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutomacaoERP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CEPController : ControllerBase
    {
        private readonly ILogger<CEPController> _logger;

        public CEPController(ILogger<CEPController> logger)
        {
            _logger = logger;
        }

        [HttpGet("BuscarCEP")]
        public async Task<ActionResult<string>> GetAsync(string cep)
        {
            HttpClient client = new HttpClient();

            try
            {
                string url = string.Format("https://viacep.com.br/ws/{0}/json", cep);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    _logger.LogInformation("Conteúdo da resposta: {0}", content);

                    return Content(content);
                }
                else
                {
                    _logger.LogError("A solicitação falhou com o código de status: {0}", response.StatusCode);
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocorreu um erro: {0}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
