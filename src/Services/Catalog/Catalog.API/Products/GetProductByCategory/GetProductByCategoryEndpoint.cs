using Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryResponse(IEnumerable<Product> Products);

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Behtare ke in category joda beshe kollan va zir majmuye product nabash, /catedories/{id}/products
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            })
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Get Products By Category")
            .Produces<GetProductByCategoryResponse>()
            .WithSummary("Get Products By Category")
            .WithName("GetProductsByCategory");
    }
}