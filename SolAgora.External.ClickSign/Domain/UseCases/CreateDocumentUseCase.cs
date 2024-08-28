using SolAgora.External.ClickSign.Api.Dtos.Request;
using SolAgora.External.ClickSign.Api.Dtos.Response;
using SolAgora.External.ClickSign.Infra.ApiServices;

namespace SolAgora.External.ClickSign.Domain.UseCases;

public class CreateDocumentUseCase(IClickSignApiService clickSignApiService) : ICreateDocumentUseCase
{
    public async Task<CreateDocumentResponseDto> Create(Guid envelopeId, CreateDocumentRequestDto request, CancellationToken cancellation)
    {
        return await clickSignApiService.CreateDocumentAsync(envelopeId, request, cancellation);
    }
}

public interface ICreateDocumentUseCase
{
    Task<CreateDocumentResponseDto> Create(Guid envelopeId, CreateDocumentRequestDto request, CancellationToken cancellation);
}
