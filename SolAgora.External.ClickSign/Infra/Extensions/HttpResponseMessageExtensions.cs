using System.Text.Json;

namespace SolAgora.External.ClickSign.Infra.Extensions;

public static class HttpResponseMessageExtensions
{
    public static async Task<T> DeserializeContent<T>(this HttpResponseMessage httpResponseMessage)
    {
        return await httpResponseMessage.Content.ReadFromJsonAsync<T>() ??
            throw new JsonException($"Problem when deserializing response of type {nameof(T)}");
    }
}
