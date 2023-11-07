using AutomacaoERP.API.Models;

namespace AutomacaoERP.API.Services.Interfaces.ERP
{
    public interface IEncurtadorLinkService
    {
        Task<string> EncurtarLink(string link);
    }
}
