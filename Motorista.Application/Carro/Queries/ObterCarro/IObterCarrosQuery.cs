using Motorista.Application.ViewModel;

namespace Motorista.Application.Carro.Queries.ObterCarro
{
    public interface IObterCarrosQuery
    {
        /// <summary>
        /// Retorna um carro
        /// </summary>
        /// <param name="id">Id do carro</param>
        /// <returns>Carro</returns>
        CarroViewModel Execute(int id);
    }
}
