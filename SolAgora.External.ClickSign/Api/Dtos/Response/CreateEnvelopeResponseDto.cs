namespace SolAgora.External.ClickSign.Api.Dtos.Response;

public class CreateEnvelopeResponseDto
{
    public EnvelopeResponseData Data { get; set; } = new();
}

public class EnvelopeResponseData
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public EnvelopeResponseAttributes Attributes { get; set; } = new();
}

public class EnvelopeResponseAttributes
{
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DeadlineAt { get; set; }
    public string Locale { get; set; } = string.Empty;
    public bool AutoClose { get; set; }
    public bool RubricEnabled { get; set; }
    public int RemindInterval { get; set; }
    public bool BlockAfterRefusal { get; set; }
    public string DefaultMessage { get; set; } = string.Empty;
}


