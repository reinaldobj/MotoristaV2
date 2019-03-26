using Microsoft.Extensions.DependencyInjection;
using Motorista.Application.Carro.Commands.AtualizarCarro;
using Motorista.Application.Carro.Commands.CriarCarro;
using Motorista.Application.Carro.Commands.ExcluirCarro;
using Motorista.Application.Carro.Queries.ListarCarros;
using Motorista.Application.Carro.Queries.ObterCarro;
using Motorista.Application.Localizacao.Queries;
using Motorista.Application.Motorista.Commands.AtualizarMotorista;
using Motorista.Application.Motorista.Commands.CriarMotorista;
using Motorista.Application.Motorista.Commands.ExcluirMotorista;
using Motorista.Application.Motorista.Queries.ListarMotoristas;
using Motorista.Application.Motorista.Queries.ObterMotorista;
using Motorista.Domain.Interfaces;
using Motorista.Infra.Data.Repository;
using Motorista.Infra.GoogleMapsService;

namespace Motorista.Infra.CrossCutting.IoC
{
    public class DependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Application
            services.AddScoped<ICriarMotoristaCommand, CriarMotoristaCommand>();
            services.AddScoped<IAtualizarMotoristaCommand, AtualizarMotoristaCommand>();
            services.AddScoped<IExcluirMotoristaCommand, ExcluirMotoristaCommand>();
            services.AddScoped<IObterMotoristaQuery, ObterMotoristaQuery>();
            services.AddScoped<IListarMotoristasQuery, ListarMotoristasQuery>();

            services.AddScoped<ICriarCarroCommand, CriarCarroCommand>();
            services.AddScoped<IAtualizarCarroCommand, AtualizarCarroCommand>();
            services.AddScoped<IExcluirCarroCommand, ExcluirCarroCommand>();
            services.AddScoped<IObterCarrosQuery, ObterCarrosQuery>();
            services.AddScoped<IListarCarrosQuery, ListarCarrosQuery>();

            services.AddScoped<IObterCoordenadasQuery, ObterCoordenadasQuery>();

            #endregion

            #region Infrastructure
            services.AddScoped<ILocalizacaoService, GoogleMapsClient>();

            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<ICarroRepository, CarroRepository>();
            #endregion
        }
    }
}
