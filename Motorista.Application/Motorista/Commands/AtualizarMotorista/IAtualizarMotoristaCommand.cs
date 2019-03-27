using System.Threading.Tasks;
using Motorista.Application.ViewModel;

namespace Motorista.Application.Motorista.Commands.AtualizarMotorista
{
    public interface IAtualizarMotoristaCommand
    {
        /// <summary>
        /// Atualiza o cadastro de motorista
        /// </summary>
        /// <param name="motorista"></param>
        void Execute(MotoristaViewModel motoristaViewModel);
    }
}
