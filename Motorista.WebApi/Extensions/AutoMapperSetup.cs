using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Motorista.Application.AutoMapper;

namespace Motorista.WebApi.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
