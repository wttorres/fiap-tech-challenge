using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fakers
{
    public static class ConfigurationFaker
    {
        public static IConfiguration ComValoresValidos()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { "ENVIA_NOTIFICACAO_INTERVALO_MINUTOS", "1" }
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        public static IConfiguration ComIntervaloInvalido()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { "ENVIA_NOTIFICACAO_INTERVALO_MINUTOS", "abc" }
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }
    }
}