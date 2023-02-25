using Domain.Inventories.Enums;

namespace Domain.Inventories;

public class Movement
{
    public Movement(Stock stock)
    {
        Stock = stock;
    }

    public Guid Id { get; set; }

    public Stock Stock { get; set; }

    public DateTime MovementDate { get; set; }

    public MovementType Type { get; set; }

    public decimal Quantity { get; set; }

    public decimal MovementValue { get; set; }

    public void RecordInbound(decimal quantity)
    {
        MovementDate = DateTime.UtcNow;
        Type = MovementType.Inbound;
        Quantity = quantity;
    }

    public void RecordOutbound(decimal quantity)
    {
        MovementDate = DateTime.UtcNow;
        Type = MovementType.Outbound;
        Quantity = quantity;
    }
}
