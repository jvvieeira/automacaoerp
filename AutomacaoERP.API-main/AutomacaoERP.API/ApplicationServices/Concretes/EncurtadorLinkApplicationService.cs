using AutomacaoERP.API.ApplicationServices.Interfaces;
using AutomacaoERP.API.Models;
using AutomacaoERP.API.Services.Interfaces.ERP;
using AutomacaoERP.API.Services.Interfaces.Zenvia;

namespace AutomacaoERP.API.ApplicationServices.Concretes
{
    public class EncurtadorLinkApplicationService : IEncurtadorLinkApplicationService
    {
        private readonly IEncurtadorLinkService _iencurtadorLinkService;

        public EncurtadorLinkApplicationService(IEncurtadorLinkService iencurtadorLinkService)
        {
            _iencurtadorLinkService = iencurtadorLinkService;
        }

        public Task<string> EncurtarLink(string link)
        {
            return _iencurtadorLinkService.EncurtarLink(link);
        }
    }
}
