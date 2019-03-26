using System.Collections.Generic;
using AutoMapper;
using Motorista.Application.ViewModel;
using Motorista.Domain.Interfaces;
using CarroModel = Motorista.Domain.Models.Carro;

namespace Motorista.Application.Carro.Queries.ListarCarros
{
    public class ListarCarrosQuery : IListarCarrosQuery
    {
        private readonly ICarroRepository carroRepository;
        private readonly IMapper mapper;

        public ListarCarrosQuery(
            ICarroRepository carroRepository,
            IMapper mapper)
        {
            this.carroRepository = carroRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CarroViewModel> Execute(string modelo)
        {
            var carros = carroRepository.Listar(m =>
                (string.IsNullOrEmpty(modelo) || m.Marca == modelo)
            );

            return mapper.Map<IEnumerable<CarroModel>, IEnumerable<CarroViewModel>>(carros);
        }
    }
}
