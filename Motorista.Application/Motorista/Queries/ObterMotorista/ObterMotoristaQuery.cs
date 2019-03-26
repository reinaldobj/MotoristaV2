using AutoMapper;
using Motorista.Application.ViewModel;
using Motorista.Domain.Interfaces;
using MotoristaModel = Motorista.Domain.Models.Motorista;

namespace Motorista.Application.Motorista.Queries.ObterMotorista
{
    public class ObterMotoristaQuery : IObterMotoristaQuery
    {
        private readonly IMotoristaRepository motoristaRepository;
        private readonly IMapper mapper;

        public ObterMotoristaQuery(
            IMotoristaRepository motoristaRepository,
            IMapper mapper)
        {
            this.motoristaRepository = motoristaRepository;
            this.mapper = mapper;
        }

        public MotoristaViewModel Execute(int id)
        {
            var motorista = motoristaRepository.ObterPorId(id);

            return mapper.Map<MotoristaModel, MotoristaViewModel>(motorista);
        }
    }
}
