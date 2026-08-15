namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price,
    string Name,
    Guid Id
);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint
{ 
}