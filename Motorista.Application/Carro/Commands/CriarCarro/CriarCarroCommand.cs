using AutoMapper;
using Motorista.Application.ViewModel;
using Motorista.Domain.Interfaces;

namespace Motorista.Application.Carro.Commands.CriarCarro
{
    public class CriarCarroCommand : ICriarCarroCommand
    {
        private readonly ICarroRepository carroRepository;
        private readonly IMapper mapper;

        public CriarCarroCommand(
            ICarroRepository carroRepository,
            IMapper mapper)
        {
            this.carroRepository = carroRepository;
            this.mapper = mapper;
        }

        public void Execute(CarroViewModel carroViewModel)
        {
            var carro = mapper.Map<CarroViewModel, Domain.Models.Carro>(carroViewModel);

            carroRepository.Adicionar(carro);
            carroRepository.SalvarAlteracoes();
        }
    }
}
