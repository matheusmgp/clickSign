using System.Text.Json.Serialization;

namespace SolAgora.External.ClickSign.Api.Dtos.Request;

public class CreateDocumentRequestDto
{
    public string Type { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string ContentBase { get; set; } = string.Empty;
}


public class CreateDocumentRequest
{
    public DocumentData Data { get; set; } = new();
}

public class DocumentData
{
    public string Type { get; set; } = string.Empty;
    public DocumentAttributes Attributes { get; set; } = new();
}

public class DocumentAttributes
{
    public string Filename { get; set; } = string.Empty;
    
    [JsonPropertyName("content_base64")]
    public string ContentBase64 { get; set; } = string.Empty;
}
