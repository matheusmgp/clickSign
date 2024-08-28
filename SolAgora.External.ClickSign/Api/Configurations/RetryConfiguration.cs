using Polly.Extensions.Http;
using Polly;

namespace SolAgora.External.ClickSign.Api.Configurations;

public static class RetryConfiguration
{
    public static IHttpClientBuilder AddRetryPolicy(this IHttpClientBuilder httpClient, int retryCount = 3, int retryTime = 2)
    {
        httpClient.AddPolicyHandler(GetRetryPolicy(retryCount, retryTime));

        return httpClient;
    }

    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount, int retryTime)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(retryTime, retryAttempt)));
    }
}
