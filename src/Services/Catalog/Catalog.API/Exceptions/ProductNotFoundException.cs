using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid productId) : base("Product not found")
    {
        ProductId = productId;
    }
    public Guid ProductId { get; set; }
}
