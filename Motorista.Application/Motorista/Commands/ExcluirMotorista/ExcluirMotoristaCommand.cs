using Motorista.Domain.Interfaces;

namespace Motorista.Application.Motorista.Commands.ExcluirMotorista
{
    public class ExcluirMotoristaCommand : IExcluirMotoristaCommand
    {
        private readonly IMotoristaRepository motoristaRepository;

        public ExcluirMotoristaCommand(
            IMotoristaRepository motoristaRepository)
        {
            this.motoristaRepository = motoristaRepository;
        }

        public void Execute(int id)
        {
            motoristaRepository.Excluir(id);
            motoristaRepository.SalvarAlteracoes();
        }
    }
}
