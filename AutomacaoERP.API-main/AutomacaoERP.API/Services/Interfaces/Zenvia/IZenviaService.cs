using AutomacaoERP.API.Models;

namespace AutomacaoERP.API.Services.Interfaces.Zenvia
{
    public interface IZenviaService
    {
        Task<HttpResponseMessage?> EnviarMensagem(Mensagem mensagem);

    }
}
