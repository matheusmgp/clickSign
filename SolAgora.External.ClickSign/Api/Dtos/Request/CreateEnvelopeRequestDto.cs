namespace SolAgora.External.ClickSign.Api.Dtos.Request;

public class CreateEnvelopeRequestDto
{
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Locale { get; set; } = string.Empty;
    public bool? AutoClose { get; set; }
    public int? RemindInterval { get; set; }
    public bool? BlockAfterRefusal { get; set; }
    public DateTime? DeadlineAt { get; set; }
}

public class CreateEnvelopeRequest
{
    public EnvevelopeData Data { get; set; } = new();
}

public class EnvevelopeData
{
    public string Type { get; set; } = string.Empty;
    public EnvevelopeAttributes Attributes { get; set; } = new();
}

public class EnvevelopeAttributes
{
    public string Name { get; set; } = string.Empty;
}
