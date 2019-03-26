using AutoMapper;

namespace Motorista.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings() =>
            new MapperConfiguration(cfg => {
                cfg.AddProfile(new EnderecoToEnderecoViewModelProfile());
                cfg.AddProfile(new CarroToCarroViewModelProfile());
                cfg.AddProfile(new MotoristaToMotoristaViewModelProfile());
            });
    }
}
