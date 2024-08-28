namespace SolAgora.External.ClickSign.Infra.ApiServices;

public class ApiServiceBase
{
    protected readonly HttpClient _httpClient;
    protected string _baseServiceUri = "";

    protected ApiServiceBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
