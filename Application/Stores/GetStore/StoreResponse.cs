namespace Application.Stores.GetStore;

public sealed record StoreResponse(
    Guid Id,
    string Name,
    string Address,
    string PhoneNumber,
    string Email,
    string Manager,
    bool Active);
