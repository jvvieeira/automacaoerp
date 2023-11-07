using AutomacaoERP.API.Models;

namespace AutomacaoERP.API.Services.Interfaces.ERP
{
    public interface IERPService
    {
        Task<IQueryable<Conta>> ConsultarContasAReceber();
        Task<ClientesCadastro> ConsultarTodosClientes();
        Task<BoletoGerado> ConsultarBoleto(long idBoleto);
        Task<Cliente> ConsultarCliente(long idCliente);
    }
}
