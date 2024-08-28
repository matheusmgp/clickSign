using SolAgora.External.ClickSign.Api.Dtos.Request;
using SolAgora.External.ClickSign.Api.Dtos.Response;
using SolAgora.External.ClickSign.Infra.ApiServices;

namespace SolAgora.External.ClickSign.Domain.UseCases;

public class CreateEnvelopeUseCase(IClickSignApiService clickSignApiService) : ICreateEnvelopeUseCase
{
    public async Task<CreateEnvelopeResponseDto> Create(CreateEnvelopeRequestDto request, CancellationToken cancellation)
    {
        return await clickSignApiService.CreateEnvelopeAsync(request, cancellation);
    }
}

public interface ICreateEnvelopeUseCase
{
    Task<CreateEnvelopeResponseDto> Create(CreateEnvelopeRequestDto request, CancellationToken cancellation);
}
