using Domain.Abstractions;
using Domain.Products;

namespace Domain.Inventories;

public class Stock : AggregateRoot
{
    public Stock(
        Product product,
        Store store)
    {
        Product = product;
        Store = store;
        Details = new();
    }

    public Guid Id { get; set; }

    public Store Store { get; set; }

    public Product Product { get; set; }

    public decimal Quantity { get; set; }

    public decimal Value { get; set; }

    public bool Available { get; set; }

    public List<StockDetail> Details { get; set; }

    public void AddStockDetail(string? size, string? color, decimal quantity)
    {
        if (!Details.Any(d => d.Size == size && d.Color == color) ||
            !Details.Any(d => d.Size == size) ||
            !Details.Any(d => d.Color == color))
        {
            Details.Add(new StockDetail(size, color, quantity, Product.Price));
        }
    }

    public void RemoveStockDetail(Guid id)
    {
        if (Details.Any(d => d.Id == id))
        {
            var detail = Details.First(s => s.Id == id);
            Details.Remove(detail);
        }
    }

    public void CalculateValueByStockDetail()
    {
        if (Details.Count > 0)
        {
            Value = Details.Sum(s => s.Value);
        }
    }
}
