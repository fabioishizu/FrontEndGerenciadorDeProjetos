using ProjetosFrontEnd.Models;
using System.Text;
using System.Net;

namespace ProjetosFrontEnd.Utils;

public class AuxiliarRequisicao
{
    private static Configuration configuracao;
    public static async Task<T> RequisitarAPI<T>(HttpMethod metodoHttp, string uriRota, IHttpClientFactory clientFactory, string body = null)
    {
        if (configuracao == null)
            configuracao = LerConfiguracao();

        var request = new HttpRequestMessage(metodoHttp, configuracao.UrlAPI + "/" + uriRota);

        if (!string.IsNullOrEmpty(body))
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

        var client = clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<T>();
        }
        else
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new ArgumentException(await response.Content.ReadAsStringAsync());

            throw new Exception("Ocorreu um erro! Por favor, tente novamente mais tarde.");
        }
    }

    private static Configuration LerConfiguracao()
    {
        return System.Text.Json.JsonSerializer.Deserialize<Configuration>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"appsettings.json")));
    }
}
