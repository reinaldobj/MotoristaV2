using System.Threading.Tasks;
using Motorista.Domain.Models;
using static Motorista.Domain.Models.GeolocationResult;

namespace Motorista.Domain.Interfaces
{
    public interface ILocalizacaoService
    {
        /// <summary>
        /// Retorna as Coordenadas(Latitude e Longitude) de um endereço
        /// </summary>
        /// <param name="endereco">Endereço que deseja obter as coordenadas</param>
        Task<Localizacao> ObterCoordenadas(Endereco endereco);
    }
}
