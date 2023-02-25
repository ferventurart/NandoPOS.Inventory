namespace Domain.Products;

public sealed class ProductCategory
{
    public Guid Id { get; init; }

    public string Name { get; set; } = string.Empty;

    public bool Active { get; set; }
}
