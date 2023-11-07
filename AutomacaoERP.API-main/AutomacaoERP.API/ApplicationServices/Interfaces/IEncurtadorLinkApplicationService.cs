using AutomacaoERP.API.Models;

namespace AutomacaoERP.API.ApplicationServices.Interfaces
{
    public interface IEncurtadorLinkApplicationService
    {
        Task<string> EncurtarLink(string link);
       
    }
}
