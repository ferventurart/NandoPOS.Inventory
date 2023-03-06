using Application.Stores.CreateStore;
using Application.Stores.GetAllStores;
using Application.Stores.GetStore;
using Application.Stores.UpdateStore;
using Domain.Shared;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;
using Presentation.Contracts.Stores;

namespace Presentation.Controllers;

[Route("api/stores")]
public sealed class StoresController : ApiController
{
    public StoresController(ISender sender)
            : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        Result<List<StoresResponse>> response = await Sender.Send(new GetStoresQuery(), cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        Result<StoreResponse> response = await Sender.Send(new GetStoreByIdQuery(id), cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
    [FromBody] CreateStoreRequest request,
    CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateStoreCommand>();

        Result<Guid> result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Value },
            result.Value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
    Guid id,
    [FromBody] UpdateStoreRequest request,
    CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return BadRequest("Identifier mismatch error");
        }

        var command = request.Adapt<UpdateStoreCommand>();

        var result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return NoContent();
    }
}
