using Application.Abstractions.Messaging;
using Domain.Inventories;
using Domain.Shared;
using Marten;

namespace Application.Stores.CreateStore;

internal sealed class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand, Guid>
{
    private readonly IDocumentSession _session;

    public CreateStoreCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<Result<Guid>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        Store store = new(request.Name, request.Address, request.PhoneNumber, request.Manager, request.Email);

        _session.Store(store);

        await _session.SaveChangesAsync(cancellationToken);

        return store.Id;
    }
}
