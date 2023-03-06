using Application.Abstractions.Messaging;
using Domain.Inventories;
using Domain.Shared;
using Marten;

namespace Application.Stores.GetAllStores;

internal sealed class GetStoresQueryHandler
     : IQueryHandler<GetStoresQuery, List<StoresResponse>>
{
    private readonly IQuerySession _session;

    public GetStoresQueryHandler(IQuerySession session)
    {
        _session = session;
    }

    public async Task<Result<List<StoresResponse>>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<StoresResponse> stores = await _session
            .Query<Store>()
            .Select(t => new StoresResponse(
                t.Id,
                t.Name,
                t.Address,
                t.PhoneNumber,
                t.Email,
                t.Manager,
                t.Active))
            .ToListAsync(cancellationToken);

        return stores.ToList();
    }
}
