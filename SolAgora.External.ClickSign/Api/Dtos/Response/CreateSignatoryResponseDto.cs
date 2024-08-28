namespace SolAgora.External.ClickSign.Api.Dtos.Response;

public class CreateSignatoryResponseDto
{
    public SignatoryResponseData Data { get; set; } = new();
}

public class SignatoryResponseData
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public SignatoryResponseAttributes Attributes { get; set; } = new();
}

public class SignatoryResponseAttributes
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Documentation { get; set; } = string.Empty;
}
