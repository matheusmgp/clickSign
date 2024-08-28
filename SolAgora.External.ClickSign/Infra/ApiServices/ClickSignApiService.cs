using SolAgora.External.ClickSign.Api.Dtos.Request;
using SolAgora.External.ClickSign.Api.Dtos.Response;
using SolAgora.External.ClickSign.Infra.Extensions;

namespace SolAgora.External.ClickSign.Infra.ApiServices;

public class ClickSignApiService(HttpClient httpClient) : ApiServiceBase(httpClient), IClickSignApiService
{
    public async Task<CreateEnvelopeResponseDto> CreateEnvelopeAsync(CreateEnvelopeRequestDto request, CancellationToken cancellation)
    {
        var uri = "envelopes";
        var newRequest = MakeEnvelopeRequestBody(request);

        var response = await _httpClient.PostAsJsonAsync(uri, newRequest, cancellation);

        if (response.IsSuccessStatusCode)
            return await response.DeserializeContent<CreateEnvelopeResponseDto>();

        return new CreateEnvelopeResponseDto();
    }

    public async Task<CreateDocumentResponseDto> CreateDocumentAsync(Guid envelopeId, CreateDocumentRequestDto request, CancellationToken cancellation)
    {
        var uri = $"envelopes/{envelopeId}/documents/";

        var newRequest = MakeDocumentRequestBody(request);

        var response = await _httpClient.PostAsJsonAsync(uri, newRequest, cancellation);

        if (response.IsSuccessStatusCode)
            return await response.DeserializeContent<CreateDocumentResponseDto>();

        return new CreateDocumentResponseDto();
    }

    public async Task<CreateSignatoryResponseDto> CreateSignatoryAsync(Guid envelopeId, CreateSignatoryRequestDto request, CancellationToken cancellation)
    {
        var uri = $"envelopes/{envelopeId}/signers/";

        var newRequest = MakeSignatoryRequestBody(request);

        var response = await _httpClient.PostAsJsonAsync(uri, newRequest, cancellation);

        if (response.IsSuccessStatusCode)
            return await response.DeserializeContent<CreateSignatoryResponseDto>();

        return new CreateSignatoryResponseDto();
    }

    private static CreateEnvelopeRequest MakeEnvelopeRequestBody(CreateEnvelopeRequestDto request)
    {
        return new CreateEnvelopeRequest()
        {
            Data = new EnvevelopeData()
            {
                Type = request.Type,
                Attributes = new EnvevelopeAttributes()
                {
                    Name = request.Name,
                }
            }
        };
    }

    private static CreateDocumentRequest MakeDocumentRequestBody(CreateDocumentRequestDto request)
    {
        return new CreateDocumentRequest()
        {
            Data = new DocumentData()
            {
                Type = request.Type,
                Attributes = new DocumentAttributes()
                {
                    Filename = request.FileName,
                    ContentBase64 = request.ContentBase
                }
            }
        };
    }

    private static CreateSignatoryRequest MakeSignatoryRequestBody(CreateSignatoryRequestDto request)
    {
        return new CreateSignatoryRequest()
        {
            Data = new SignatoryData()
            {
                Type = request.Type,
                Attributes = new SignatoryAttributes()
                {
                    Name = request.Name,
                    Documentation = request.Documentation,
                    Email = request.Email,
                }
            }
        };
    }
}


public interface IClickSignApiService
{
    Task<CreateEnvelopeResponseDto> CreateEnvelopeAsync(CreateEnvelopeRequestDto request, CancellationToken cancellation);
    Task<CreateDocumentResponseDto> CreateDocumentAsync(Guid envelopeId, CreateDocumentRequestDto request, CancellationToken cancellation);
    Task<CreateSignatoryResponseDto> CreateSignatoryAsync(Guid envelopeId, CreateSignatoryRequestDto request, CancellationToken cancellation);
}

