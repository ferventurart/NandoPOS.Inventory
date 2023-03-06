using Application.Abstractions.Messaging;

namespace Application.Stores.GetAllStores;

public sealed record GetStoresQuery : IQuery<List<StoresResponse>>;
