using AutoMapper;
using Motorista.Application.ViewModel;
using Motorista.Domain.Models;

namespace Motorista.Application.AutoMapper
{
    public class EnderecoToEnderecoViewModelProfile : Profile
    {
        public EnderecoToEnderecoViewModelProfile() => 
            CreateMap<EnderecoViewModel, Endereco>().ReverseMap();
    }
}
