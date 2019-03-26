using Motorista.Application.ViewModel;

namespace Motorista.Application.Carro.Commands.CriarCarro
{
    public interface ICriarCarroCommand
    {
        /// <summary>
        /// Inclui o cadastro de um carro
        /// </summary>
        /// <param name="carroViewModel">Carro que será incluído</param>
        void Execute(CarroViewModel carroViewModel);
    }
}
