using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        var products = new List<Product>
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "IPhone 16",
                Description = "some description",
                ImageFile = "produc1.png",
                Price = 950.00M,
                Category = new List<string>{"Smart Phone"}
            }
        };

        return products;
    }
}
