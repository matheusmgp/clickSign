namespace SolAgora.External.ClickSign.Api.Dtos.Request;

public class CreateSignatoryRequestDto
{
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;  
    public string Email { get; set; } = string.Empty;
    public string Documentation { get; set; } = string.Empty;
}

public class CreateSignatoryRequest
{
    public SignatoryData Data { get; set; } = new();
}

public class SignatoryData
{
    public string Type { get; set; } = string.Empty;
    public SignatoryAttributes Attributes { get; set; } = new();
}

public class SignatoryAttributes
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;  
    public string Documentation { get; set; } = string.Empty;
}

