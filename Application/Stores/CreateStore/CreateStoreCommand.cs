using Application.Abstractions.Messaging;

namespace Application.Stores.CreateStore;

public record CreateStoreCommand(
    string Name,
    string Address,
    string PhoneNumber,
    string Manager,
    string Email) : ICommand<Guid>;
