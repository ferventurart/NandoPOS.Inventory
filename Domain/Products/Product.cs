﻿namespace Domain.Products;

public sealed class Product
{
    public Guid Id { get; init; }

    public string? Barcode { get; set; }

    public string? Sku { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public decimal? StockMin { get; set; }

    public decimal? StockMax { get; set; }

    public List<string> Sizes { get; set; } = new();

    public List<string> Colors { get; set; } = new();

    public ProductCategory ProductCategory { get; set; } = new();

    public bool Active { get; set; }
}
