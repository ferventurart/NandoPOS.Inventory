namespace Presentation.Contracts.Stores;

public sealed record UpdateStoreRequest(
    Guid Id,
    string Name,
    string Address,
    string PhoneNumber,
    string Manager,
    string Email,
    bool Active);
