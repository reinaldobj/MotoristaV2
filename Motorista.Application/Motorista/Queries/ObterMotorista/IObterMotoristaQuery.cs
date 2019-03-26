using Motorista.Application.ViewModel;

namespace Motorista.Application.Motorista.Queries.ObterMotorista
{
    public interface IObterMotoristaQuery
    {
        /// <summary>
        /// Retorna um motorista
        /// </summary>
        /// <param name="id">Id do motorista</param>
        /// <returns></returns>
        MotoristaViewModel Execute(int id);
    }
}
