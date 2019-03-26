using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Motorista.Domain.Interfaces;
using Motorista.Infra.GoogleMapsService;

namespace Motorista.Infra.CrossCutting.IoC
{
    public static class HttpClientFactory
    {
        public static void RegisterServices(
            IServiceCollection services,
            IConfiguration configuration) =>
        #region HttpClients
                services.AddHttpClient<ILocalizacaoService, GoogleMapsClient>((s, c) => {
                    c.BaseAddress = new Uri(configuration["GoogleMapsAPI:URLApi"]);
                });
        #endregion
    }
}
