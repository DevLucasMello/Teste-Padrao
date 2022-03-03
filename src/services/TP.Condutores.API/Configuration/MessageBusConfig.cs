﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TP.Condutores.Application.Services;
using TP.Core.Utils;
using TP.MessageBus;

namespace TP.Identidade.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<AtualizarVeiculoCondutorIntegrationHandler>()
                .AddHostedService<RemoverVeiculoCondutorIntegrationHandler>();
        }
    }
}