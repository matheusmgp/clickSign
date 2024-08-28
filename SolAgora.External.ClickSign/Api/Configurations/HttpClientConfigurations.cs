using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using SolAgora.External.ClickSign.Api.Extensions;
using SolAgora.External.ClickSign.Api.Handlers;
using SolAgora.External.ClickSign.Infra.ApiServices;

namespace SolAgora.External.ClickSign.Api.Configurations;

public static class HttpClientConfigurations
{
    private const string TokenIdHeader = "Authorization";

    public static IServiceCollection AddHttpClientConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var baseAddress = configuration.Validate("Uris:ClickSignService");
        var authorizationToken = configuration.Validate("Authentication:Authorization");

        services.AddHttpClient<IClickSignApiService, ClickSignApiService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Add(TokenIdHeader, authorizationToken);
            //client.DefaultRequestHeaders.ContentType = new MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        })
        .AddRetryPolicy()
        .AddHttpMessageHandler<ApiErrorLoggingHandler>();

        return services;
    }
}
