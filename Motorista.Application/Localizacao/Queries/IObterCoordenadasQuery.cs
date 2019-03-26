using System.Threading.Tasks;
using Motorista.Domain.Models;

namespace Motorista.Application.Localizacao.Queries
{
    public interface IObterCoordenadasQuery
    {
        /// <summary>
        /// Retorna as coordenadas do endereço
        /// </summary>
        /// <param name="endereco">Endereço que deseja buscar as coordenadas</param>
        /// <returns></returns>
        Task<GeolocationResult.Localizacao> Execute(Endereco endereco);
    }
}
