using Application.Abstractions.Messaging;

namespace Application.Stores.GetStore;

public sealed record GetStoreByIdQuery(
    Guid Id) : IQuery<StoreResponse>;
