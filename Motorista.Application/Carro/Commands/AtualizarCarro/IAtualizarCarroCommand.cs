using Motorista.Application.ViewModel;

namespace Motorista.Application.Carro.Commands.AtualizarCarro
{
    public interface IAtualizarCarroCommand
    {
        /// <summary>
        /// Altera o cadastro de um carro
        /// </summary>
        /// <param name="carroViewModel">Carro de será alterado</param>
        void Execute(CarroViewModel carroViewModel);
    }
}
