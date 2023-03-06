namespace Application.Stores.GetAllStores;

public sealed record StoresResponse(
    Guid Id,
    string Name,
    string Address,
    string PhoneNumber,
    string Email,
    string Manager,
    bool Active);
