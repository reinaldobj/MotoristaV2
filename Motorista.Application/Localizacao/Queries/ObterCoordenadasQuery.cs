using System.Threading.Tasks;
using Motorista.Domain.Interfaces;
using Motorista.Domain.Models;

namespace Motorista.Application.Localizacao.Queries
{
    public class ObterCoordenadasQuery : IObterCoordenadasQuery
    {
        private readonly ILocalizacaoService localizacaoService;

        public ObterCoordenadasQuery(ILocalizacaoService localizacaoService)
        {
            this.localizacaoService = localizacaoService;
        }

        public Task<GeolocationResult.Localizacao> Execute(Endereco endereco)
        {
            return localizacaoService.ObterCoordenadas(endereco);
        }
    }
}
