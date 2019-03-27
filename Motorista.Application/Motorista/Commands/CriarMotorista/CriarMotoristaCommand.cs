using System.Threading.Tasks;
using AutoMapper;
using Motorista.Application.Carro.Queries.ObterCarro;
using Motorista.Application.Localizacao.Queries;
using Motorista.Application.ViewModel;
using Motorista.Domain.Interfaces;
using Motorista.Domain.Models;
using MotoristaModel = Motorista.Domain.Models.Motorista;

namespace Motorista.Application.Motorista.Commands.CriarMotorista
{
    public class CriarMotoristaCommand : ICriarMotoristaCommand
    {
        private readonly IMotoristaRepository motoristaRepository;
        private readonly IObterCoordenadasQuery obterCoordenadasQuery;
        private readonly IObterCarrosQuery obterCarroQuery;
        private readonly IMapper mapper;

        public CriarMotoristaCommand(
            IMotoristaRepository motoristaRepository,
            IObterCoordenadasQuery obterCoordenadasQuery,
            IObterCarrosQuery obterCarroQuery,
            IMapper mapper)
        {
            this.motoristaRepository = motoristaRepository;
            this.obterCoordenadasQuery = obterCoordenadasQuery;
            this.obterCarroQuery = obterCarroQuery;
            this.mapper = mapper;
        }

        public async Task Execute(MotoristaViewModel motoristaViewModel)
        {
            PreencherIdCarro(motoristaViewModel);

            await PreencherCoordenadasEndereco(motoristaViewModel);

            MotoristaModel motorista = mapper.Map<MotoristaViewModel, MotoristaModel>(motoristaViewModel);

            motoristaRepository.Adicionar(motorista);
            motoristaRepository.SalvarAlteracoes();
        }

        private async Task PreencherCoordenadasEndereco(MotoristaViewModel motoristaViewModel)
        {
            Endereco endereco = mapper.Map<EnderecoViewModel, Endereco>(motoristaViewModel.Endereco);

            GeolocationResult.Localizacao localizacao = await obterCoordenadasQuery.Execute(endereco);
            motoristaViewModel.Endereco.Latitude = localizacao.Latitude.ToString();
            motoristaViewModel.Endereco.Longitude = localizacao.Longitude.ToString();
        }

        private void PreencherIdCarro(MotoristaViewModel motoristaViewModel)
        {
            if (motoristaViewModel.IdCarro > 0) {
                motoristaViewModel.IdCarro = obterCarroQuery.Execute(motoristaViewModel.IdCarro).Id;
            }
        }
    }
}
