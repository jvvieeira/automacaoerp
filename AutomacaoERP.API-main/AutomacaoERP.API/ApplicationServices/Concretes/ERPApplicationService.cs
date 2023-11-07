using AutomacaoERP.API.ApplicationServices.Interfaces;
using AutomacaoERP.API.Models;
using AutomacaoERP.API.Services.Interfaces.ERP;
using AutomacaoERP.API.Services.Interfaces.Zenvia;

namespace AutomacaoERP.API.ApplicationServices.Concretes
{
    public class ERPApplicationService : IERPApplicationService
    {
        private readonly IERPService _ierpService;
        private readonly IEncurtadorLinkService _iencurtadorLinkService;
        public ERPApplicationService(IERPService ierpService, IEncurtadorLinkService iencurtadorLinkService)
        {
            this._ierpService = ierpService;
            this._iencurtadorLinkService = iencurtadorLinkService;
        }

        public Task<BoletoGerado> ConsultarBoleto(long idBoleto)
        {
            return this._ierpService.ConsultarBoleto(idBoleto);
        }

        public Task<Cliente> ConsultarCliente(long idCliente)
        {
            return this._ierpService.ConsultarCliente(idCliente);
        }

        public Task<IQueryable<Conta>> ConsultarContasAReceber()
        {
            return this._ierpService.ConsultarContasAReceber();
        }

        public Task<ClientesCadastro> ConsultarTodosClientes()
        {
            return this._ierpService.ConsultarTodosClientes();
        }

        public async Task<List<Mensagem>> MontarMensagens()
        {
            var contasReceber = await ConsultarContasAReceber();
            var clientes = await ConsultarTodosClientes();
            var mensagens = new List<Mensagem>();

            var clientesDictionary = clientes?.clientes_cadastro?.ToDictionary(x => x.codigo_cliente_omie.ToString(), x => x);

            foreach (var item in contasReceber)
            {
                if (clientesDictionary.TryGetValue(item.codigo_cliente_fornecedor, out var cliente))
                {
                    var boletoGerado = await ConsultarBoleto(long.Parse(item.codigo_lancamento_omie));
                    var celularContato = string.Format("55{0}{1}", cliente.telefone1_ddd, cliente.telefone1_numero);
                    var linkCurto = await _iencurtadorLinkService.EncurtarLink(boletoGerado.cLinkBoleto);

                    mensagens.Add(new Mensagem
                    {
                        celular = celularContato,
                        link = linkCurto
                    });
                }
            }

            return mensagens;

        }
    }
}
