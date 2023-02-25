using Domain.Abstractions;
using Domain.Products;

namespace Domain.Inventory;

public class Inventory : AggregateRoot
{
    public Inventory(Store store, Product product, decimal stock)
    {
        Store = store;
        Product = product;
        Stock = stock;
    }

    public Guid Id { get; set; }

    public Store Store { get; set; }

    public Product Product { get; set; }

    public decimal InitialStock { get; set; }

    public decimal Stock { get; set; }

    public bool Available { get; set; }
}
