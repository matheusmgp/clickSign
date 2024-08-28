using SolAgora.External.ClickSign.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SolAgora.External.ClickSign.Api.Handlers;

public class ApiErrorLoggingHandler : DelegatingHandler
{
    private readonly ILogger<ApiErrorLoggingHandler> _logger;

    public ApiErrorLoggingHandler(ILogger<ApiErrorLoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode is false)
            {
                await LogResponseContent(request.RequestUri!.ToString(), response);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.UnprocessableEntity:
                        var responseContent = await response.Content.ReadFromJsonAsync<CustomErrorFrameworkResponse>(cancellationToken);
                        throw new ValidationException(responseContent!.Detail);
                    default:
                        break;
                }

                response.EnsureSuccessStatusCode();
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while sending HTTP request.");
            throw;
        }
    }

    private async Task LogResponseContent(string requestUri, HttpResponseMessage response)
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        var message = $"Request not performed successfully to this address: {requestUri}, " +
            $"returning with status code {response.StatusCode} and response: {responseContent}";

        _logger.LogWarning("{message}", message);
    }
}
