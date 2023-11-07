using AutomacaoERP.API.Models;
using AutomacaoERP.API.Services.Interfaces.ERP;
using AutomacaoERP.API.Services.Interfaces.Zenvia;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http.Headers;

namespace AutomacaoERP.API.Services.Concretes.ERP
{
    public class EncurtadorLinkService : IEncurtadorLinkService
    {
        public async Task<string> EncurtarLink(string link)
        {
            if (string.IsNullOrEmpty(link))
                return string.Empty;

            try
            {
                var client = new HttpClient();
                var url = "https://api.encurtador.dev/encurtamentos";
                var payload = $@"{{
                              ""url"": ""{link}""
                            }}";

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var content = new StringContent(payload, null, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var result = JsonConvert.DeserializeObject<LinkCurto>(await response.Content.ReadAsStringAsync());

                return result.urlEncurtada;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um errono encurtar link : " + ex.Message);
            }
        }
    }
}
