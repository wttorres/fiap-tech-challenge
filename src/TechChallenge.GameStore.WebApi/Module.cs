using System;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TechChallenge.GameStore.WebApi.Notificacoes.Enviar;

namespace TechChallenge.GameStore.WebApi;

public static class Module
{
    public static void AddWebApi(this IServiceCollection services)
    {
        AddControllers(services);
        AddSwagger(services);
        AddJobs(services);
    }

    private static void AddJobs(IServiceCollection services)
    {
        services.AddHostedService<EnviarNotificacoesJob>();
    }

    private static void AddControllers(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
    }
    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.TagActionsBy(api =>
            {
                var groupName = api.GroupName;
                return !string.IsNullOrEmpty(groupName)
                    ? new[] { groupName }
                    : [api.ActionDescriptor.RouteValues["controller"]];
            });

            c.DocInclusionPredicate((_, _) => true);
            
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Insira o token JWT no campo abaixo. Exemplo: Bearer {seu_token}",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });
            
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

}