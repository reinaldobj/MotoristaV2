namespace Motorista.Application.Motorista.Commands.ExcluirMotorista
{
    public interface IExcluirMotoristaCommand
    {
        /// <summary>
        /// Exclui o cadastro de um motorista
        /// </summary>
        /// <param name="motorista"></param>
        void Execute(int id);
    }
}
