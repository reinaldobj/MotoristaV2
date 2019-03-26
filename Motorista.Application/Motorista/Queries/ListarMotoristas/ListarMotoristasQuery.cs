using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Motorista.Application.ViewModel;
using Motorista.Domain.Enum;
using Motorista.Domain.Interfaces;
using MotoristaModel = Motorista.Domain.Models.Motorista;

namespace Motorista.Application.Motorista.Queries.ListarMotoristas
{
    public class ListarMotoristasQuery : IListarMotoristasQuery
    {
        private readonly IMotoristaRepository motoristaRepository;
        private readonly IMapper mapper;

        public ListarMotoristasQuery(
            IMotoristaRepository motoristaRepository,
            IMapper mapper)
        {
            this.motoristaRepository = motoristaRepository;
            this.mapper = mapper;
        }

        public IEnumerable<MotoristaViewModel> Execute(
            string nomeMotorista = null,
            CampoOrdenacaoEnum? ordenacao = CampoOrdenacaoEnum.Nenhum)
        {
            var motoristas = motoristaRepository.Listar(m =>
                (string.IsNullOrEmpty(nomeMotorista) || m.Nome.Contains(nomeMotorista))
            );

            if (ordenacao == CampoOrdenacaoEnum.Nome)
                return mapper.Map<IEnumerable<MotoristaModel>, IEnumerable<MotoristaViewModel>>(motoristas).OrderBy(m => m.Nome);

            if (ordenacao == CampoOrdenacaoEnum.UltimoNome)
                return mapper.Map<IEnumerable<MotoristaModel>, IEnumerable<MotoristaViewModel>>(motoristas).OrderBy(m => m.UltimoNome);

            return mapper.Map<IEnumerable<MotoristaModel>, IEnumerable<MotoristaViewModel>>(motoristas);
        }
    }
}
