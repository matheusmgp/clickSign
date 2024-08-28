namespace SolAgora.External.ClickSign.Domain.ValueObject;

public record CustomErrorResponse
{
    public string Title { get; set; } = string.Empty;
    public IDictionary<string, string[]>? Errors { get; set; }
}

public record CustomErrorFrameworkResponse
{
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public string Detail { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = [];
}
