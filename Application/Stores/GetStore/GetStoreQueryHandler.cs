using Application.Abstractions.Messaging;
using Domain.Inventories;
using Domain.Shared;
using Marten;

namespace Application.Stores.GetStore;

internal sealed class GetStoreQueryHandler
     : IQueryHandler<GetStoreByIdQuery, StoreResponse>
{
    private readonly IQuerySession _session;

    public GetStoreQueryHandler(IQuerySession session)
    {
        _session = session;
    }

    public async Task<Result<StoreResponse>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {
        var store = await _session.LoadAsync<Store>(request.Id, cancellationToken);

        if (store is null)
        {
            return Result.Failure<StoreResponse>(new Error(
                    "Store.NotFound",
                    $"The record with the id {request.Id} was not found"));
        }

        var response = new StoreResponse(
            store.Id,
            store.Name,
            store.Address,
            store.PhoneNumber,
            store.Email,
            store.Manager,
            store.Active);

        return Result.Success(response);
    }
}
