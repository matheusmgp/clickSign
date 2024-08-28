using System.Text.Json;

namespace SolAgora.External.ClickSign.Api.Extensions;

public static class ConfigurationExtension
{
    public static string Validate(this IConfiguration configuration, string key)
    {
        return configuration[key] ?? throw new JsonException($"{key} not found");
    }
}
