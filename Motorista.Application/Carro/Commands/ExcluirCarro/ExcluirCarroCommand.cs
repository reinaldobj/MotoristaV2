using AutoMapper;
using Motorista.Domain.Interfaces;

namespace Motorista.Application.Carro.Commands.ExcluirCarro
{
    public class ExcluirCarroCommand : IExcluirCarroCommand
    {
        private readonly ICarroRepository carroRepository;
        private readonly IMapper mapper;

        public ExcluirCarroCommand(
            ICarroRepository carroRepository,
            IMapper mapper)
        {
            this.carroRepository = carroRepository;
            this.mapper = mapper;
        }

        public void Execute(int id)
        {
            carroRepository.Excluir(id);
            carroRepository.SalvarAlteracoes();
        }
    }
}
