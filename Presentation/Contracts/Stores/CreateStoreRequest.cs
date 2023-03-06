namespace Presentation.Contracts.Stores;

public sealed record CreateStoreRequest(
    string Name,
    string Address,
    string PhoneNumber,
    string Manager,
    string Email);
