using AutoMapper;
using Motorista.Application.ViewModel;

namespace Motorista.Application.AutoMapper
{
    public class MotoristaToMotoristaViewModelProfile : Profile
    {
        public MotoristaToMotoristaViewModelProfile() =>
            CreateMap<MotoristaViewModel, Domain.Models.Motorista>()
                .ForMember(d => d.Carro, opt => opt.MapFrom(src => new Domain.Models.Carro { Id = src.IdCarro }))
                .ReverseMap()
                .ForMember(d => d.IdCarro, opt => opt.MapFrom(src => src.Carro.Id));
    }
}
