namespace SolAgora.External.ClickSign.Api.Dtos.Response;

public class CreateDocumentResponseDto
{
    public DocumentResponseData Data { get; set; } = new();
}

public class DocumentResponseData
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public DocumentResponseAttributes Attributes { get; set; } = new();
}

public class DocumentResponseAttributes
{
    public string Status { get; set; } = string.Empty;
    public string Filename { get; set; } = string.Empty;
    public string Template { get; set; } = string.Empty;
}

