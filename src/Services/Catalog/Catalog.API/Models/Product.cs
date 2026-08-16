namespace Catalog.API.Models;

public class Product
{
    public List<string> Category { get; set; } = [];
    public string Description { get; set; } = null!;
    public string ImageFile { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public Guid Id { get; set; }
}