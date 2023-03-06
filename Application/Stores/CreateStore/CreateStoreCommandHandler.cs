using Application.Abstractions.EventBus;
using Application.Abstractions.Messaging;
using Application.Products.CreateProduct;
using Domain.Inventories;
using Domain.Products;
using Domain.Shared;
using Marten;

namespace Application.Stores.CreateStore;

internal sealed class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand, Guid>
{
    private readonly IDocumentSession _session;
    private readonly IEventBus _eventBus;

    public CreateStoreCommandHandler(IDocumentSession session, IEventBus eventBus)
    {
        _session = session;
        _eventBus = eventBus;
    }

    public async Task<Result<Guid>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        Store store = new(request.Name, request.Address, request.PhoneNumber, request.Manager, request.Email);

        _session.Store(store);

        await _session.SaveChangesAsync(cancellationToken);

        await _eventBus.PublishAsync(
        new StoreCreatedEvent
        {
            Id = store.Id,
            Name = store.Name,
            Address = store.Address,
            Email = store.Email,
            Manager = store.Manager,
            PhoneNumber = store.PhoneNumber,
            Active = store.Active
        },
        cancellationToken);

        return store.Id;
    }
}
