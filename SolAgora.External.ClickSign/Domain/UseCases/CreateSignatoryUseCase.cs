using SolAgora.External.ClickSign.Api.Dtos.Request;
using SolAgora.External.ClickSign.Api.Dtos.Response;
using SolAgora.External.ClickSign.Infra.ApiServices;

namespace SolAgora.External.ClickSign.Domain.UseCases;

public class CreateSignatoryUseCase(IClickSignApiService clickSignApiService) : ICreateSignatoryUseCase
{
    public async Task<CreateSignatoryResponseDto> Create(Guid envelopeId, CreateSignatoryRequestDto request, CancellationToken cancellation)
    {
        return await clickSignApiService.CreateSignatoryAsync(envelopeId, request, cancellation);
    }
}

public interface ICreateSignatoryUseCase
{
    Task<CreateSignatoryResponseDto> Create(Guid envelopeId, CreateSignatoryRequestDto request, CancellationToken cancellation);
}
