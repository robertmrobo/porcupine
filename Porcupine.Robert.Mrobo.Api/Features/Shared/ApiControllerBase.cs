using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Porcupine.Robert.Mrobo.Api.Features.Shared;

[Route("api/v1")]
public abstract class ApiControllerBase : ControllerBase
{
    private IMediator? _mediator;
    private IMapper? _mapper;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();
}