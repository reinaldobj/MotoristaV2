using AutoMapper;
using Motorista.Application.ViewModel;

namespace Motorista.Application.AutoMapper
{
    public class CarroToCarroViewModelProfile : Profile
    {
        public CarroToCarroViewModelProfile() => 
            CreateMap<CarroViewModel, Domain.Models.Carro>().ReverseMap();
    }
}
