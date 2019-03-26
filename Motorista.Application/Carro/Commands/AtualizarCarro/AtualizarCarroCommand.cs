using AutoMapper;
using Motorista.Application.ViewModel;
using Motorista.Domain.Interfaces;
using CarroModel = Motorista.Domain.Models.Carro;

namespace Motorista.Application.Carro.Commands.AtualizarCarro
{
    public class AtualizarCarroCommand : IAtualizarCarroCommand
    {
        private readonly ICarroRepository carroRepository;
        private readonly IMapper mapper;

        public AtualizarCarroCommand(
            ICarroRepository carroRepository,
            IMapper mapper)
        {
            this.carroRepository = carroRepository;
            this.mapper = mapper;
        }

        public void Execute(CarroViewModel carroViewModel)
        {
            var carro = mapper.Map<CarroViewModel, CarroModel>(carroViewModel);

            carroRepository.Atualizar(carro);
            carroRepository.SalvarAlteracoes();
        }
    }
}
