using BuildingBlocks.CQRS.Command;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductResult(Guid Id);

public record CreateProductCommand(
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price,
    string Name,
    Guid Id
) : ICommand<CreateProductResult>;

internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
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
        //skip saving to database
        return new CreateProductResult(Guid.NewGuid());
    }
}