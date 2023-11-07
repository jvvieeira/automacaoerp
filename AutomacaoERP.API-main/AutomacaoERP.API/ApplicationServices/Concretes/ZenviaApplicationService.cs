using AutomacaoERP.API.ApplicationServices.Interfaces;
using AutomacaoERP.API.Models;
using AutomacaoERP.API.Services.Interfaces.ERP;
using AutomacaoERP.API.Services.Interfaces.Zenvia;

namespace AutomacaoERP.API.ApplicationServices.Concretes
{
    public class ZenviaApplicationService : IZenviaApplicationService
    {
        private readonly IZenviaService _zenviaService;

        public ZenviaApplicationService(IZenviaService zenviaService)
        {
            _zenviaService = zenviaService;
        }

        public Task<HttpResponseMessage?> EnviarMensagem(Mensagem mensagem)
        {
            return _zenviaService.EnviarMensagem(mensagem);
        }
    }
}
