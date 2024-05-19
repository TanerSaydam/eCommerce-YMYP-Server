using eCommerceServer.Domain.Abstractions;

namespace eCommerceServer.Domain.Products;
public sealed class Product : Entity
{
    public string Name { get; set; }
}
