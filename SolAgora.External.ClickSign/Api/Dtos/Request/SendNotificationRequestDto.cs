namespace SolAgora.External.ClickSign.Api.Dtos.Request;

public class SendNotificationRequestDto
{
    public NotificationData Data { get; set; } = new();
}


public class NotificationData
{
    public string Type { get; set; } = string.Empty;
    public NotificationAttributes Attributes { get; set; } = new();
}

public class NotificationAttributes
{
    public string Message { get; set; } = string.Empty;
}
