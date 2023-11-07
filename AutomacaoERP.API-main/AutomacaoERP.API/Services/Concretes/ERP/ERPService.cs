using AutomacaoERP.API.Models;
using AutomacaoERP.API.Services.Interfaces.ERP;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;

namespace AutomacaoERP.API.Services.Concretes.ERP
{
    public class ERPService : IERPService
    {
        private const string CONST_MENSAGEM_CLIENTE_NAO_ENCONTRADO = "Código do Cliente não encontrado";

        public async Task<BoletoGerado> ConsultarBoleto(long idBoleto)
        {
            try
            {
                var call = "ObterBoleto";
                var param = $@"{{
                              ""nCodTitulo"": {idBoleto},
                              ""cCodIntTitulo"": """"
                           }}";

                var url = "https://app.omie.com.br/api/v1/financas/contareceberboleto/";
                var request = MontarPayload(url, call, param);
                var response = await ExecutarRequest(request);

                BoletoGerado? result = new BoletoGerado();

                if (response.FirstOrDefault().ToString().Contains("faultstring"))
                    return result;

                result = JsonConvert.DeserializeObject<BoletoGerado>(response);

                return result == null ? new BoletoGerado() : result;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar boleto: " + ex.Message);
            }
        }

        public async Task<Cliente> ConsultarCliente(long idCliente)
        {
            try
            {
                var call = "ConsultarCliente";
                var param = $@"{{
                              ""codigo_cliente_omie"": {idCliente},
                              ""codigo_cliente_integracao"": """"
                           }}";

                var url = "https://app.omie.com.br/api/v1/geral/clientes/";
                var request = MontarPayload(url, call, param);
                var response = await ExecutarRequest(request);

                var result = JsonConvert.DeserializeObject<Cliente>(response);


                return result == null ? new Cliente() : result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar cliente: " + ex.Message);
            }
        }

        public async Task<IQueryable<Conta>> ConsultarContasAReceber()
        {
            try
            {
                var qtdRegistros = 100;
                var call = "ListarContasReceber";
                var url = "https://app.omie.com.br/api/v1/financas/contareceber/";
                var contas = new List<Conta>();

                using (var client = new HttpClient())
                {
                    for (int pagina = 1; ; pagina++)
                    {
                        var param = $@"{{
                                            ""pagina"": {pagina},
                                            ""registros_por_pagina"": {qtdRegistros},
                                            ""apenas_importado_api"": ""N"",
                                            ""filtrar_por_status"": ""AVENCER""
                                        }}";

                        var request = MontarPayload(url, call, param);
                        var response = await ExecutarRequest(client, request);

                        if (string.IsNullOrEmpty(response))
                            break;

                        var result = JsonConvert.DeserializeObject<ContaReceber>(response);

                        if (result?.conta_receber_cadastro != null)
                        {
                            foreach (var conta in result.conta_receber_cadastro)
                            {
                                contas.Add(new Conta
                                {
                                    codigo_cliente_fornecedor = conta.codigo_cliente_fornecedor.ToString(),
                                    codigo_lancamento_omie = conta.codigo_lancamento_omie.ToString()
                                });
                            }
                        }

                        if (pagina >= result?.total_de_paginas)
                            break;
                    }
                }

                return contas.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex.Message);
            }
        }

        private async Task<string> ExecutarRequest(HttpClient client, HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

        private HttpRequestMessage MontarPayload(string url, string call, string param)
        {
            var payload = $@"{{
                              ""call"": ""{call}"",
                              ""app_key"": ""3386754279909"",
                              ""app_secret"": ""fc2468231721c16f4d2eee2c105a741f"",
                              ""param"": [
                                      {param}
                                  ]
                            }}";

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var content = new StringContent(payload, null, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Content = content;

            return request;
        }

        private async Task<string> ExecutarRequest(HttpRequestMessage request)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    //return await response.Content.ReadAsStringAsync();
                }
                //else
                //    return CONST_MENSAGEM_CLIENTE_NAO_ENCONTRADO;
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex.Message);

            }
        }

        public async Task<ClientesCadastro> ConsultarTodosClientes()
        {
            try
            {
                var call = "ListarClientes";
                var param = $@"{{
                              ""pagina"": 1,
                              ""registros_por_pagina"": 300,
                              ""apenas_importado_api"": ""N""
                           }}";

                var url = "https://app.omie.com.br/api/v1/geral/clientes/";
                var request = MontarPayload(url, call, param);
                var response = await ExecutarRequest(request);

                ClientesCadastro? result = new ClientesCadastro();

                result = JsonConvert.DeserializeObject<ClientesCadastro>(response);

                return result == null ? new ClientesCadastro() : result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar todos os clientes: " + ex.Message);

            }

        }

    }
}
