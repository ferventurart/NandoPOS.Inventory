using Application.Abstractions.Messaging;
using Domain.Inventories;
using Domain.Shared;
using Marten;

namespace Application.Stores.UpdateStore;

internal sealed class UpdateStoreCommandHandler : ICommandHandler<UpdateStoreCommand>
{
    private readonly IDocumentSession _session;

    public UpdateStoreCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<Result> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await _session.LoadAsync<Store>(request.Id, cancellationToken);

        if (store is null)
        {
            return Result.Failure(new Error(
                    "Store.NotFound",
                    $"The record with the id {request.Id} was not found"));
        }

        store.ChangeName(request.Name);
        store.ChangeAddress(request.Address);
        store.ChangePhoneNumber(request.PhoneNumber);
        store.ChangeEmail(request.Email);
        store.ChangeManager(request.Manager);

        if (store.Active != request.Active)
        {
            store.ChangeStatus();
        }

        _session.Update(store);

        await _session.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
