using System.Collections.Generic;
using Motorista.Application.ViewModel;

namespace Motorista.Application.Carro.Queries.ListarCarros
{
    public interface IListarCarrosQuery
    {
        /// <summary>
        /// Retorna todos os carros cadastrados
        /// </summary>
        /// <returns>Lista de Carros</returns>
        IEnumerable<CarroViewModel> Execute(string modelo);
    }
}
