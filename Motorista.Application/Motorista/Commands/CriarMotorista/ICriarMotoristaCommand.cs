using System.Threading.Tasks;
using Motorista.Application.ViewModel;

namespace Motorista.Application.Motorista.Commands.CriarMotorista
{
    public interface ICriarMotoristaCommand
    {
        /// <summary>
        /// Cadastra um novo motorista
        /// </summary>
        /// <param name="motorista"></param>
        Task Execute(MotoristaViewModel motoristaViewModel);
    }
}
