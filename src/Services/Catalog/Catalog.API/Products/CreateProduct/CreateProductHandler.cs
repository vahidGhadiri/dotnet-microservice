namespace Catalog.API.Products.CreateProduct;

public record CreateProductResult(Guid Id);

public record CreateProductCommand(
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price,
    string Name
) : ICommand<CreateProductResult>;

internal class CreateProductHandler(IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Description = command.Description,
            ImageFile = command.ImageFile,
            Category = command.Category,
            Price = command.Price,
            Name = command.Name,
        };
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        return new CreateProductResult(product.Id);
    }
}