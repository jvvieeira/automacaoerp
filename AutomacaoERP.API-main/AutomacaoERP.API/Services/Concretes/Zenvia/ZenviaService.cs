using AutomacaoERP.API.Models;
using AutomacaoERP.API.Services.Interfaces.ERP;
using AutomacaoERP.API.Services.Interfaces.Zenvia;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http.Headers;

namespace AutomacaoERP.API.Services.Concretes.Zenvia
{
    public class ZenviaService : IZenviaService
    {
        private readonly IConfiguration _configuration;

        public ZenviaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage?> EnviarMensagem(Mensagem mensagem)
        {
            if (string.IsNullOrEmpty(mensagem.celular))
                return null;

            try
            {
                var client = new HttpClient();
                var url = "https://api.zenvia.com/v2/channels/sms/messages";
                var payload = $@"{{
                              ""from"": ""fish-ninja"",
                              ""to"": ""{mensagem.celular}"",
                              ""contents"":[{{
                                                ""type"": ""text"",
                                                ""text"": ""{mensagem.link}""
                                            }}]
                            }}";

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var content = new StringContent(payload, null, "application/json");
                var tokenZenvia = _configuration.GetValue<string>("ZenviaToken");

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Headers.Add("X-API-TOKEN", tokenZenvia);

                request.Content = content;

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var result = JsonConvert.DeserializeObject<LinkCurto>(await response.Content.ReadAsStringAsync());

                return  response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro no envio da mensagem : " + ex.Message);
            }
        }

    }
}
