namespace Domain.Inventories;

public class StockDetail
{
    public StockDetail(
        string? size,
        string? color,
        decimal quantity,
        decimal value)
    {
        Size = size;
        Color = color;
        Quantity = quantity;
        Value = value;
    }

    public Guid Id { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public decimal Quantity { get; set; }

    public decimal Value { get; set; }
}
