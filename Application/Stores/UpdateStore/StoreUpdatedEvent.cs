namespace Application.Stores.UpdateStore;

public sealed record StoreUpdatedEvent
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Manager { get; set; } = string.Empty;

    public bool Active { get; set; }
}
