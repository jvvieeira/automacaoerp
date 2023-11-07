using AutomacaoERP.API.Models;

namespace AutomacaoERP.API.ApplicationServices.Interfaces
{
    public interface IZenviaApplicationService
    {
        Task<HttpResponseMessage> EnviarMensagem(Mensagem mensagem);
       
    }
}
