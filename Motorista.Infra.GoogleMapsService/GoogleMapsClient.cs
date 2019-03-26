using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Motorista.Domain.Interfaces;
using Motorista.Domain.Models;
using static Motorista.Domain.Models.GeolocationResult;

namespace Motorista.Infra.GoogleMapsService
{
    public class GoogleMapsClient : ILocalizacaoService
    {
        private readonly string tokenApi;
        private readonly HttpClient client;

        public GoogleMapsClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.tokenApi = configuration["GoogleMapsAPI:KeyApi"];
            this.client = httpClient;
        }

        public async Task<Localizacao> ObterCoordenadas(Endereco endereco)
        {
            var enderecoCompleto = System.Net.WebUtility.UrlEncode($"{endereco.Rua},{endereco.Numero},{endereco.Cidade},{endereco.UF}");

            var jsonResult = await client.GetStringAsync($"?address={enderecoCompleto}&key={this.tokenApi}");
            var coordenadas = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(jsonResult);

            return coordenadas.Resultados.FirstOrDefault().Coordenadas.Localizacao;
        }
    }
}
