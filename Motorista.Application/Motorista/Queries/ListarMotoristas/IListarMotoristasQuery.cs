using System.Collections.Generic;
using Motorista.Application.ViewModel;
using Motorista.Domain.Enum;

namespace Motorista.Application.Motorista.Queries.ListarMotoristas
{
    public interface IListarMotoristasQuery
    {
        /// <summary>
        /// Retorna os motoristas cadastrados
        /// </summary>
        /// <param name="ordenacao">Opção de Ordenação</param>
        /// <returns></returns>
        IEnumerable<MotoristaViewModel> Execute(
            string nomeMotorista = null,
            CampoOrdenacaoEnum? ordenacao = CampoOrdenacaoEnum.Nenhum);
    }
}
