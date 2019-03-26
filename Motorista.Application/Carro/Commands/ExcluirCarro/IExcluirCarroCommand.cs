namespace Motorista.Application.Carro.Commands.ExcluirCarro
{
    public interface IExcluirCarroCommand
    {
        /// <summary>
        /// Exclui o cadastro de um carro
        /// </summary>
        /// <param name="carro"></param>
        void Execute(int id);
    }
}
