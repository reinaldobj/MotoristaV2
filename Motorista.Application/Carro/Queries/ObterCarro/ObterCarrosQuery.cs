using AutoMapper;
using Motorista.Application.ViewModel;
using Motorista.Domain.Interfaces;

namespace Motorista.Application.Carro.Queries.ObterCarro
{
    public class ObterCarrosQuery : IObterCarrosQuery
    {
        private readonly ICarroRepository carroRepository;
        private readonly IMapper mapper;

        public ObterCarrosQuery(
            ICarroRepository carroRepository,
            IMapper mapper)
        {
            this.carroRepository = carroRepository;
            this.mapper = mapper;
        }

        public CarroViewModel Execute(int id)
        {
            var carro = carroRepository.ObterPorId(id);

            return mapper.Map<Domain.Models.Carro, CarroViewModel>(carro);
        }
    }
}
