using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.GameStore.Application.Usuarios.Cadastrar;

namespace TechChallenge.GameStore.Application;

public static class Module
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining<CadastrarCommand>());
    }
}