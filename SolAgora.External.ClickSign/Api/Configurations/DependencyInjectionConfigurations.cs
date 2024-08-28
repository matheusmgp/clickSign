using SolAgora.External.ClickSign.Api.Handlers;
using SolAgora.External.ClickSign.Domain.UseCases;
using SolAgora.External.ClickSign.Infra.ApiServices;

namespace SolAgora.External.ClickSign.Api.Configurations;

public static class DependencyInjectionConfigurations
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<ApiErrorLoggingHandler>();
        services.AddScoped<IClickSignApiService, ClickSignApiService>();
        services.AddScoped<ICreateDocumentUseCase, CreateDocumentUseCase>();
        services.AddScoped<ICreateEnvelopeUseCase, CreateEnvelopeUseCase>();
        services.AddScoped<ICreateSignatoryUseCase, CreateSignatoryUseCase>();

        return services;
    }
}
