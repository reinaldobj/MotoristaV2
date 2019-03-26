using AutoMapper;
using Motorista.Application.ViewModel;
using Motorista.Domain.Interfaces;
using MotoristaModel = Motorista.Domain.Models.Motorista;

namespace Motorista.Application.Motorista.Commands.AtualizarMotorista
{
    public class AtualizarMotoristaCommand : IAtualizarMotoristaCommand
    {
        private readonly IMotoristaRepository motoristaRepository;
        private readonly IMapper mapper;

        public AtualizarMotoristaCommand(
            IMotoristaRepository motoristaRepository,
            IMapper mapper)
        {
            this.motoristaRepository = motoristaRepository;
            this.mapper = mapper;
        }

        public void Execute(MotoristaViewModel motoristaViewModel)
        {
            var motorista = mapper.Map<MotoristaViewModel, MotoristaModel>(motoristaViewModel);

            motoristaRepository.Atualizar(motorista);
            motoristaRepository.SalvarAlteracoes();
        }
    }
}
