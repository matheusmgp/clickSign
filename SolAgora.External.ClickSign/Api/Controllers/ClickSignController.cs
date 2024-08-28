using Kombi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolAgora.External.ClickSign.Api.Dtos.Request;
using SolAgora.External.ClickSign.Api.Dtos.Response;
using SolAgora.External.ClickSign.Domain.UseCases;
using SolAgora.External.ClickSign.Domain.ValueObject;

namespace SolAgora.External.ClickSign.Api.Controllers;

[Route("click-sign")]
[ApiController]
public class ClickSignController(
    ICreateEnvelopeUseCase createEnvelopeUseCase,
    ICreateDocumentUseCase createDocumentUseCase,
    ICreateSignatoryUseCase createSignatoryUseCase) : ControllerBase
{
    [HttpPost("envelope")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CreateEnvelopeResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(CustomErrorFrameworkResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateEnvelopeResponseDto>> CreateEnvelope(CreateEnvelopeRequestDto request, CancellationToken cancellationToken)
    {
        var response = await createEnvelopeUseCase.Create(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("/{envelopeId}/document")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CreateDocumentResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(CustomErrorFrameworkResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateDocumentResponseDto>> CreateDocument(Guid envelopeId, CreateDocumentRequestDto request, CancellationToken cancellationToken)
    {
        var response = await createDocumentUseCase.Create(envelopeId, request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("/{envelopeId}/signatory")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CreateSignatoryResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(CustomErrorFrameworkResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateSignatoryResponseDto>> CreateSignatory(Guid envelopeId, CreateSignatoryRequestDto request, CancellationToken cancellationToken)
    {
        var response = await createSignatoryUseCase.Create(envelopeId, request, cancellationToken);
        return Ok(response);
    }
}


