using Domain.Products;
using Mapster;
using Marten;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Application.Products.CreateProduct;

public sealed class ProductCreatedEventConsumer : IConsumer<ProductCreatedEvent>
{
    private readonly ILogger<ProductCreatedEventConsumer> _logger;
    private readonly IDocumentSession _session;

    public ProductCreatedEventConsumer(ILogger<ProductCreatedEventConsumer> logger, IDocumentSession session)
    {
        _logger = logger;
        _session = session;
    }

    public async Task Consume(ConsumeContext<ProductCreatedEvent> context)
    {
        var product = context.Message.Adapt<Product>();

        _session.Store<Product>(product);

        await _session.SaveChangesAsync();

        _logger.LogInformation("Product created: {@Product}", context.Message);
    }
}
