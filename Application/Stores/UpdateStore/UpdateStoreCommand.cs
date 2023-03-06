using Application.Abstractions.Messaging;

namespace Application.Stores.UpdateStore;

public record UpdateStoreCommand(
    Guid Id,
    string Name,
    string Address,
    string PhoneNumber,
    string Manager,
    string Email,
    bool Active) : ICommand;
