using System.Threading.Tasks;
using AutoMapper;
using Motorista.Application.Carro.Queries.ObterCarro;
using Motorista.Application.ViewModel;
using Motorista.Domain.Interfaces;
using MotoristaModel = Motorista.Domain.Models.Motorista;
using CarroModel = Motorista.Domain.Models.Carro;

namespace Motorista.Application.Motorista.Commands.AtualizarMotorista
{
    public class AtualizarMotoristaCommand : IAtualizarMotoristaCommand
    {
        private readonly IMotoristaRepository motoristaRepository;
        private readonly IObterCarrosQuery obterCarroQuery;
        private readonly IMapper mapper;

        public AtualizarMotoristaCommand(
            IMotoristaRepository motoristaRepository,
            IObterCarrosQuery obterCarroQuery,
            IMapper mapper)
        {
            this.motoristaRepository = motoristaRepository;
            this.obterCarroQuery = obterCarroQuery;
            this.mapper = mapper;
        }

        public void Execute(MotoristaViewModel motoristaViewModel)
        {
            var motorista = mapper.Map<MotoristaViewModel, MotoristaModel>(motoristaViewModel);

            PreencherCarro(motorista);

            motoristaRepository.Atualizar(motorista);
            motoristaRepository.SalvarAlteracoes();
        }

        private void PreencherCarro(MotoristaModel motorista)
        {
            if (motorista.Carro.Id > 0) {
                var carroViewModel = obterCarroQuery.Execute(motorista.Carro.Id);

                if (carroViewModel != null) {
                    motorista.Carro = mapper.Map<CarroViewModel, CarroModel>(carroViewModel);
                }
            }
        }
    }
}
