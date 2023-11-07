using AutomacaoERP.API.Models;

namespace AutomacaoERP.API.ApplicationServices.Interfaces
{
    public interface IERPApplicationService
    {
        Task<IQueryable<Conta>> ConsultarContasAReceber();
        Task<ClientesCadastro> ConsultarTodosClientes();
        Task<BoletoGerado> ConsultarBoleto(long idBoleto);
        Task<Cliente> ConsultarCliente(long idCliente);
        Task<List<Mensagem>> MontarMensagens();
    }
}
